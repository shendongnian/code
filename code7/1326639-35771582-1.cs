    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Shell;
    using System.Windows.Forms.Integration;
    using System.Diagnostics;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
                Load += Form1_Load;
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                HtmlDocument doc = webBrowser1.Document;
                HtmlElement HTMLControl2 = doc.GetElementById("searchInput");
    
                if (HTMLControl2 != null)
                {
                    // HTMLControl2.Style = "display: none";
                    HTMLControl2.InnerText = textBox1.Text;
    
                    HTMLControl2.Focus();
    
                    SendKeys.SendWait("{ENTER}");
                    textBox1.Focus();
    
                }
            }
        }
    }
