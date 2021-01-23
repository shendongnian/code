            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
                //add new code here
                XmlNode inXmlNode = null;
                XmlAttributeCollection attributes = null;
                inXmlNode.Attributes.CopyTo(atttributes);
                foreach(XmlAttribute attribute in attributes)
                {
                   string name = attribute.Name;
                   string value = attribute.Value;
                }
            }
