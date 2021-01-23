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
            private void button1_Click(object sender, EventArgs e)
            {
                string input =
                    "<People>" +
                        "<Person>" +
                            "<Name>TestPeron</Name>" +
                            "<Age>29</Age>" +
                            "<Email>me@testmail.com</Email>" +
                        "</Person>" +
                    "</People>";
                XDocument doc = XDocument.Parse(input);
                foreach(XElement person in doc.Descendants("Person"))
                {
                    string message = string.Format("Name : {0}, Age : {1}, Email : {2}",
                        person.Element("Name").Value,
                        person.Element("Age").Value,
                        person.Element("Name").Value);
                    MessageBox.Show(message);
                    Console.ReadLine();
                }
            }
        }
    }
    ​
