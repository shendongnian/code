    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string URL = "http://news.yahoo.com/rss/";
            string[] titles = null;
            int count = -1;
            public Form1()
            {
                InitializeComponent();
                timer1.Enabled = false;
                timer1.Tick += new System.EventHandler(this.timer1_Tick);
            }
            private void buttonEnd_Click(object sender, EventArgs e)
            {
                timer1.Enabled = false;
            }
            private void buttonStart_Click(object sender, EventArgs e)
            {
                timer1.Interval = 20000;
                count = -1;
                timer1.Enabled = true;
            }
     
            private void timer1_Tick(object sender, EventArgs e)
            {
                if ((count == -1) || (count >= titles.Count()))
                {
                    GetFeeds();
                    count = 0;
                }
                textBox1.Text = titles[count++];
            }
            public void GetFeeds()
            {
                timer1.Enabled = false;
                XDocument doc = XDocument.Load(URL);
                titles = doc.Descendants("item").Select(x => (string)x.Element("title")).ToArray();
                timer1.Enabled = true;
            }
        }
    }
