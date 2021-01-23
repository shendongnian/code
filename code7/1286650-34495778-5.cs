    XmlDocument xmlDoc = new XmlDocument();
            
            xmlDoc.LoadXml(File.ReadAllText(@"{path}\xml.xml", Encoding.Default));
            XmlNodeList nodeList = xmlDoc.SelectNodes("//*['.' = substring(name(), string-length(name())- string-length('.') +1)]");
            foreach (XmlNode node in nodeList)
            {
                string newName = node.Name.Replace(".", "");
                // create new (renamed) Content node
                XmlNode newNode = xmlDoc.CreateElement(newName);
                newNode.InnerXml = node.InnerXml;
                // replace existing BatteryTest node with newly renamed Content node
                node.ParentNode.InsertBefore(newNode, node);
                node.ParentNode.RemoveChild(node);
            }
            xmlDoc.Save(@"{path}\xml.xml");
