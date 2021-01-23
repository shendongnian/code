    XmlDocument Doc = new XmlDocument();
            Doc.Load("example.xml");
            XmlNodeList nodeList = Doc.SelectNodes("/ITEM");
            foreach (XmlNode node in nodeList)
            {
              foreach (XmlAttribute attr in node.Attributes)
              {
                string name = attr.Name;
                string value = attr.Value;
              }
              
            }
