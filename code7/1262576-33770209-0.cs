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
    
    namespace TestFormFieldCycle
    {
        public partial class Form1 : Form
        {
            List<string> rList = new List<string>();
            int mainIndex = 0;
    
            public Form1()
            {
                InitializeComponent();
                for (int i = 0; i < 100; i++)
                {
                    int areaCode = 0;
                    int phone1 = 0;
                    int phone2 = 0;
                    String phoneNumber = String.Empty;
                    do
                    {
                        Random r = new Random();
                        areaCode = r.Next(0, 999);
                        phone1 = r.Next(0, 999);
                        phone2 = r.Next(0, 9999);
                        phoneNumber = String.Format("({0:000}) {1:000}-{2:0000}", areaCode, phone1, phone2);
                    } while (rList.Contains(phoneNumber));
                    rList.Add(phoneNumber);
                }
            }
    
            void renderAndCaptureText1()
            {
                textBox1.Text = rList[mainIndex].ToString();
                string currentPhoneNumber = textBox1.Text;
                mainIndex++;
                textBox1.Focus();
                textBox1.SelectAll();
                SendKeys.Send("^(c)");
                Application.DoEvents();
                textBox2.Focus();
                textBox2.Clear();
                SendKeys.Send("^(v)");
                Application.DoEvents();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                renderAndCaptureText1();
            }
        }
    }
