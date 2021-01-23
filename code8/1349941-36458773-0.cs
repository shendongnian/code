    xDoc.Load("Accounts.xml");
                    foreach (XmlNode node in xDoc.SelectNodes("Accounts/Table"))
                    {
                        if (node.SelectSingleNode("User").InnerText == textBox1.Text)
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                xDoc.Save("Accounts.xml");
