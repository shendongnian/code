    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.txt";
            List<TextBox> boxes = null;
            List<ComboBox> cboxes = null;
            public Form1()
            {
                InitializeComponent();
                this.FormClosing +=  new FormClosingEventHandler(Form1_FormClosing);
                boxes = new List<TextBox>() { textBox1, textBox2, textBox3 };
                cboxes = new List<ComboBox>() { comboBox1, comboBox2, comboBox3 };
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root newRoot = (Root)xs.Deserialize(reader);
                foreach (TextBox tBox in boxes)
                {
                    string name = tBox.Name;
                    Box box = newRoot.boxes.Where(x => x.name == name).FirstOrDefault();
                    tBox.Text = box.rows[0];
                }
                foreach (ComboBox  cBox in cboxes)
                {
                    string name = cBox.Name;
                    Box box = newRoot.boxes.Where(x => x.name == name).FirstOrDefault();
                    foreach (string row in box.rows)
                    {
                        cBox.Items.Add(row);
                    }
                }
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                Root root = new Root();
                root.boxes = new List<Box>();
                foreach(TextBox tBox in boxes)
                {
                    Box newBox = new Box() { name = tBox.Name, type = "Text", 
                        rows = new List<string>(){tBox.Text}
                    };
                }
                foreach (ComboBox  cBox in cboxes)
                {
                    Box newBox = new Box()
                    {
                        name = cBox.Name,
                        type = "Combo",
                        rows = GetRows(cBox)
                    };
                }
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, root, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            private List<string> GetRows(ComboBox cBox)
            {
                List<string> rows = new List<string>();
                foreach (string row in cBox.Items)
                {
                    rows.Add(row);
                }
                return rows;
            }
        }
        [XmlRoot("root")]
        public class Root
        {
            [XmlElement("boxes")]
            public List<Box> boxes { get; set; }
        }
        [XmlRoot("Box")]
        public class Box
        {
            public string name { get; set; }
            public string type { get; set; }
            [XmlElement("rows")]
            public List<string> rows { get; set; }
        }
    }
