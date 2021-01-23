    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace BrowserExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var browser = new ExtendedBrowser();
                this.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
                browser.Navigate("http://stackoverflow.com");
            }
        }
    }
