    XmlDocument doc = new XmlDocument();
                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-16", null);
                doc.AppendChild(decl);
                XmlElement ChatMapper = doc.CreateElement("ChatMapperProject");
                doc.AppendChild(ChatMapper);
                XmlNode xmldocSelect = doc.SelectSingleNode("ChatMapperProject");
                //Crteate Attribute
    
                Dictionary<String, String> attributes = new Dictionary<string, string>();
    
    
                attributes.Add("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                attributes.Add("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
                attributes.Add("Title", "");
                attributes.Add("Version", "1.5.1.0");
                attributes.Add("Author", "");
                attributes.Add("EmphasisColor1Label", "");
                attributes.Add("EmphasisColor1", "#000000");
                attributes.Add("EmphasisStyle1", "---");
                attributes.Add("EmphasisColor2Label", "");
                attributes.Add("EmphasisColor2", "#000000");
                attributes.Add("EmphasisStyle2", "---");
                attributes.Add("EmphasisColor3Label", "");
                attributes.Add("EmphasisColor3", "#000000");
                attributes.Add("EmphasisStyle3", "---");
                attributes.Add("EmphasisColor4Label", "");
                attributes.Add("EmphasisColor4", "#000000");
                attributes.Add("EmphasisStyle4", "---");
    
    
                foreach (KeyValuePair<String, String> attribute in attributes)
                {
                    ChatMapper.SetAttribute(attribute.Key, attribute.Value);
                }
