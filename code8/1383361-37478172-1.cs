    static void Main(string[] args)
    {
        int i;
        int count;
        XmlAttribute xmlAttribute;
        if ((args == null ? false : (int)args.Length != 0))
        {
            string str = args[0];
            bool flag = false;
            if (File.Exists(str))
            {
                FileInfo fileInfo = new FileInfo(str);
                if ((fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    fileInfo.Attributes = (FileAttributes)(Convert.ToInt32(fileInfo.Attributes) - Convert.ToInt32(FileAttributes.ReadOnly));
                    flag = true;
                }
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(str);
                if (xmlDocument.DocumentElement != null)
                {
                    count = xmlDocument.DocumentElement.ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes.Count;
                    for (i = 0; i < count; i++)
                    {
                        if (xmlDocument.DocumentElement != null)
                        {
                            foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes[i].ChildNodes)
                            {
                                if ((childNode.Name != "Property" ? false : childNode.Attributes != null))
                                {
                                    if ((childNode.Attributes["Name"].Value != "CreatedDate" ? false : childNode.Attributes["Type"].Value == "datetime"))
                                    {
                                        xmlAttribute = xmlDocument.CreateAttribute("StoreGeneratedPattern");
                                        xmlAttribute.Value = "Computed";
                                        childNode.Attributes.Append(xmlAttribute);
                                    }
                                }
                            }
                        }
                    }
                }
                if (xmlDocument.DocumentElement != null)
                {
                    count = xmlDocument.DocumentElement.ChildNodes[1].ChildNodes[3].ChildNodes[0].ChildNodes.Count;
                    for (i = 0; i < count; i++)
                    {
                        if (xmlDocument.DocumentElement != null)
                        {
                            foreach (XmlNode xmlNodes in xmlDocument.DocumentElement.ChildNodes[1].ChildNodes[3].ChildNodes[0].ChildNodes[i].ChildNodes)
                            {
                                if ((xmlNodes.Name != "Property" ? false : xmlNodes.Attributes != null))
                                {
                                    if ((xmlNodes.Attributes["Name"].Value != "CreatedDate" ? false : xmlNodes.Attributes["Type"].Value == "DateTime"))
                                    {
                                        xmlAttribute = xmlDocument.CreateAttribute("annotation", "StoreGeneratedPattern", "http://schemas.microsoft.com/ado/2009/02/edm/annotation");
                                        xmlAttribute.Value = "Computed";
                                        xmlNodes.Attributes.Append(xmlAttribute);
                                    }
                                }
                            }
                        }
                    }
                }
                xmlDocument.Save(str);
                if (flag)
                {
                    fileInfo.Attributes = (FileAttributes)(Convert.ToInt32(fileInfo.Attributes) + Convert.ToInt32(FileAttributes.ReadOnly));
                }
            }
        }
    }
