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
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public int questionIndex = 0;
            public List<XElement> questions = null;
            public Form1()
            {
                InitializeComponent();
                string xml =
                    "<Qustions>" +
                      "<Question id=\"1\" Cat=\"5\">" +
                        "\"Question Text 1\"" +
                      "</Question>" +
                      "<Question id=\"2\" Cat=\"2\">" +
                        "\"Question Text 2\"" +
                      "</Question>" +
                      "<Question id=\"3\" Cat=\"3\">" +
                        "\"Question Text 3\"" +
                      "</Question>" +
                      "<Question id=\"4\" Cat=\"5\">" +
                        "\"Question Text 4\"" +
                      "</Question>" +
                      "<Question id=\"5\" Cat=\"8\">" +
                        "\"Question Text 5\"" +
                      "</Question>" +
                    "</Qustions>";
                XDocument doc = XDocument.Parse(xml);
                questions = doc.Descendants("Question").ToList();
                DisplayQuestion(questionIndex);
            }
            private void buttonPrevious_Click(object sender, EventArgs e)
            {
                if (questionIndex != 0)
                {
                    DisplayQuestion(--questionIndex);
                }
            }
            private void buttonNext_Click(object sender, EventArgs e)
            {
                if (questionIndex < questions.Count - 1)
                {
                    DisplayQuestion(++questionIndex);
                }
            }
            public void DisplayQuestion(int index)
            {
                textBoxId.Text = questions[index].Attribute("id").Value;
                textBoxCat.Text = questions[index].Attribute("Cat").Value;
                textBoxCatText.Text = questions[index].Value;
            }
        }
    }
