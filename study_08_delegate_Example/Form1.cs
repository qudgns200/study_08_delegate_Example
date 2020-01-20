using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace study_08_delegate_Example
{
    public partial class Form1 : Form
    {
        delegate void ChangeTextCallback(string str); //delegate형 함수 선언
        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(CustomThread));
            thread.Start();
        }

        public void CustomThread()
        {
            for(int i=0; ; i++)
            {
                ChangeText(i.ToString());
            }
        }

        // CrossThread 상태를 확인하고
        // Invoke를 하기 위함
        public void ChangeText(string str)
        {
            if(textBox1.InvokeRequired) // Invoke가 필요하면(즉, 다른 쓰레드가 접근하면..!)
            {
                textBox1.Invoke(new ChangeTextCallback(ChangeText), new object[] { str }); //대리자 호출
            }
            else
            {
                textBox1.Text = str;
            }
        }
    }
}
