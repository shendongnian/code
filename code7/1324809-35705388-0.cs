            foreach (XmlNode node in XMLDoc.ChildNodes)
            {
                if (node.Name == "Servers")
                {
                    foreach (XmlNode serverNode in node)
                    {
                        string s = serverNode.Name;
                        MessageBox.Show(s);
                    }
                }
            }
