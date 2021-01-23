    XmlDocument xml = new XmlDocument();
                xml.Load("E://session1.xml"); // suppose that myXmlString contains "<Names>...</Names>"
                string roots = xml.DocumentElement.Name;
                treeView1.Nodes.Add(roots);
                TreeNode ParentNode = new TreeNode();
                XmlElement root = xml.DocumentElement;
                
                if (root.HasAttribute("name"))
                {
                    {
                        String name = root.GetAttribute("name");
                        ParentNode.Text = name;
                        treeView1.Nodes.Clear();
                        treeView1.Nodes.Add(ParentNode);
                    }
                }
                //while(xml.)
                XmlNodeList xnList = xml.DocumentElement.SelectNodes("/transaction/request");
                foreach (XmlNode xn in xnList)
                {
                    
                    string url = xn["URL"].InnerText;
                    ParentNode.Nodes.Add(url);
                    treeView1.ExpandAll();
                }
