        private void doSomething() 
        {
            XmlDocument doc = new XmlDocument();
            XmlNode newNode = doc.CreateElement("name");
            newNode.InnerXml = "something";
            XmlNode parentNode = doc.GetElementsByTagName("parentName")[0]; 
                // I just stuck an index on end of above line... 
                // Note that GetElementsByTagName returns an XmlNodeList
            
            int huh = 0;
            foreach (XmlNode n in parentNode.ChildNodes)
            {
                // If I understood you correctly, you want these checks?
                if (n.InnerXml == newNode.InnerXml && n.Name == newNode.Name) huh++;
            }
            if (huh == 0) parentNode.AppendChild(newNode);
        }
