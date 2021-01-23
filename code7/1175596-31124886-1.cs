    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace HTMLEditor
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load_1(object sender, EventArgs e)
            {
                webBrowser1.Navigate("C:\\AMResearch\\HTMLEditor\\blank.html");
                Application.DoEvents();
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                webBrowser1.Document.InvokeScript("createEditor");
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                string sHtml;
                sHtml = (string)webBrowser1.Document.InvokeScript("getHtml");
                MessageBox.Show(sHtml);
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                Object[] objArray = new Object[1];
                objArray[0] = "<p>Hellow World!</p>";
                webBrowser1.Document.InvokeScript("setHtml", objArray);
            }
    
        }
    }
