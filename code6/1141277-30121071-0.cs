    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace generate_XML_open_folder
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button_generate_XML_Click(object sender, EventArgs e)
            {
                string rootPath = combobox_rootpath.Text;
                var dir = new DirectoryInfo(rootPath);
    
                var doc = new XDocument(GetDirectoryXml(dir));
    
                doc.Save("test.xml");
            }
    
            private void button_open_folder_Click(object sender, EventArgs e)
            {
    
            }
    
            private void textbox_folder_to_find_TextChanged(object sender, EventArgs e)
            {
    
            }
    
            private void combobox_rootpath_SelectedIndexChanged(object sender, EventArgs e)
            {
                combobox_rootpath.Items.Clear();
                foreach (string s in Directory.GetLogicalDrives())
                {
    
                    combobox_rootpath.Items.Add(s);
    
    
                }
            }
            public static XElement GetDirectoryXml(DirectoryInfo dir)
            {
                var info = new XElement("dir",
                               new XAttribute("name", dir.Name));
    
                //foreach (var file in dir.GetFiles())
                // info.Add(new XElement("file",
                //  new XAttribute("name", file.Name)));
    
                foreach (var subDir in dir.GetDirectories())
                    info.Add(GetDirectoryXml(subDir));
    
                return info;
            }
            
        }
    }
