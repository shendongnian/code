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
                XDocument doc = XDocument.Load(FILENAME);
                TreeNode root = new TreeNode();
                treeView1.Nodes.Clear();
                foreach (XElement transaction in doc.Descendants("transaction"))
                {
                    string name = transaction.Attribute("name").Value;
                    TreeNode transactionNode = treeView1.Nodes.Add(name);
                    
                    foreach (XElement request in transaction.Elements("request"))
                    {
                        string transactionName = request.Attribute("transaction").Value;
                        string URLs = request.Element("URL").Value;
                        string node = string.Format("Transaction : {0}, URL : {1}", transactionName, URLs);
                        transactionNode.Nodes.Add(node);
                    }
                }
                treeView1.ExpandAll();
            }
        }
    }
    ​
