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
            public Form1()
            {
                InitializeComponent();
            }
            string XML = "<Root><PROMPT Label=\"OS_F014_SECTION5B\">ITINERARY</PROMPT> <GROUP> <ETC> <SECTION> </SECTION> </ETC>  </GROUP> <NUMBER>(1)</NUMBER></Root>";
            private void button1_Click(object sender, EventArgs e)
            {
                XDocument doc = XDocument.Parse(XML);
                var results = doc.Descendants("PROMPT").Where(x => x.Attribute("Label").Value == "OS_F014_SECTION5B"); 
            }
        }
    }
    ​
