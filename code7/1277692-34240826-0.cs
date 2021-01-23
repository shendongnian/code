    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Web;
    using System.Timers;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Text.RegularExpressions;
    
    
    
    namespace google_downloader
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                WebClient wc = new WebClient();
                string s= wc.DownloadString("http://finance.google.com/finance/info?client=ig&q=NSE:sbin");
                
                //index for t 
                int index7= s.IndexOf('t');
                int index8 = s.IndexOf('e');
                textBox1.Text = ("frist index is" + index7 +  "second indes is   " + index8);
              
                textBox1.Text = s.Substring(index7+6,(index8-index7)-10);
    
               
                 
                             
    
           }
        }
    }
