    foreach (XmlNode node in nodeListItems)
                    {
                        if (node.Name == "rs:data")
                        {
                           
       for (int i = 0; i < node.ChildNodes.Count; i++)
                                {
    
                                if (node.ChildNodes[i].Attributes != null)
                                {
                                    string field = node.ChildNodes[i].Attributes["ows_Title"].InnerText;
    
                                 }
                            }
                        }
                    }
