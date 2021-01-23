    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace Hyperlink_control_using_List_box
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            List<hyperlinks> hll = new List<hyperlinks>();
            private void Form1_Load(object sender, EventArgs e)
            {
                hyperlinks link1 = new hyperlinks();
                link1.hyperlink_id = 1;
                link1.hyperlink_name = "Google";
                link1.hyperlink_link = "www.google.com";
                hll.Add(link1);
    
                hyperlinks link2 = new hyperlinks();
                link2.hyperlink_id = 2;
                link2.hyperlink_name = "Facebook";
                link2.hyperlink_link = "www.facebook.com";
                hll.Add(link2);
    
                hyperlinks link3 = new hyperlinks();
                link3.hyperlink_id = 3;
                link3.hyperlink_name = "Yahoo";
                link3.hyperlink_link = "www.yahoo.com";
                hll.Add(link3);
    
                listBox1.DataSource = hll;
                listBox1.DisplayMember = "hyperlink_name";
                listBox1.ValueMember = "hyperlink_id";
            }
    
            private void listBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                foreach (hyperlinks link in hll)
                {
                    if (listBox1.SelectedValue.ToString() == link.hyperlink_id.ToString())
                    {
                        label1.Text = link.hyperlink_link;
                    }
                }
            }
        }
    
        public class hyperlinks
        {
            public int hyperlink_id { get; set; }
            public string hyperlink_name { get; set; }
            public string hyperlink_link { get; set; }
        }
    }
