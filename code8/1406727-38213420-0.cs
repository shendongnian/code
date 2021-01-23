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
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("File Name", typeof(string));
                dt.Columns.Add("File Size", typeof(string));
                dt.Columns.Add("Parent", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement folder in doc.Descendants("Folder").AsEnumerable())
                {
                    string folder_name = folder.Element("Folder_name").Value;
                    foreach (XElement file in folder.Descendants("File").AsEnumerable())
                    {
                        dt.Rows.Add(new object[] { 
                            file.Element("File_name").Value,
                            file.Element("File_size_in_bytes").Value,
                            folder_name
                        });
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
