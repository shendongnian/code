            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlstring);
            XmlNode elementNode = xmldoc.SelectSingleNode("LayoutControl/LayoutGroup/Element");
            if (elementNode != null)
            {
                foreach (XmlAttribute attribute in elementNode.Attributes)
                {
                    XmlElement elementchild = xmldoc.CreateElement(attribute.Name);
                    elementchild.InnerText = attribute.Value;
                    elementNode.AppendChild(elementchild);
                }
            }
            elementNode.Attributes.RemoveAll();
