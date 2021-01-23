    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication37
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            string[] url = new string[4] { "www.google.com", "www.bing.com","www.msn.com","www.youtube.com" };
            int currUrl = 0;
            WebBrowser web = new WebBrowser();
            private void button1_Click(object sender, EventArgs e)
            {
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
                web.ScriptErrorsSuppressed = true;
    
                web.Navigate(url[currUrl]);
                currUrl++;
            }
    
            void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            { 
                string surce = web.DocumentTitle;
    
    
    
                if (currUrl < url.Length)
                {
                    web.Navigate(url[currUrl]);
                    currUrl++;
    
    
                  
                   
                    label1.Text += surce;
    
                    
    
    
    
                }
            }
        }
    }
