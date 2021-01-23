       public static void WriteXML(string path)
        {
            // Create the xml document in memory inc. xml declaration
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            // Create the root element
            doc.AppendChild(dec);
            XmlElement rootNode = doc.CreateElement("root");
            doc.AppendChild(rootNode);
            // Create elements at root node
            XmlElement XE_level1 = doc.CreateElement("level1");
            XE_level1.InnerText = "Text";
            rootNode.AppendChild(XE_level1);
            // Create a user data element
            string s = String.Empty;
            if (String.IsNullOrEmpty(s))
            {
                XmlElement XE_level2 = doc.CreateElement("level2");
                XE_level2.IsEmpty = true;
                XE_level1.AppendChild(XE_level2);
            }
            else
            {
                XmlElement XE_level2 = doc.CreateElement("level2");
                XE_level2.InnerText = s;
                XE_level1.AppendChild(XE_level2);
            }
            doc.Save(path);
       
        }
