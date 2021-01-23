        XmlDocument doc = new XmlDocument();
        doc.Load(filename);
        XmlElement root = doc.DocumentElement;
        XmlNodeList elemList = root.GetElementsByTagName("Engine");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode head = doc.CreateNode(XmlNodeType.Element, "Host", null);
                XmlAttribute na = doc.CreateAttribute("name");
                na.Value = "url";
                // nodeTitle is not appended the document:
                //XmlNode nodeTitle = doc.CreateElement("Valve");
                // className is not appended to any node either:
                //XmlAttribute className = doc.CreateAttribute("className");
                //className.Value = "org.apache.catalina.valves.AccessLogValve";
                // this line will add your node to the last node of your document:  
                //doc.DocumentElement.LastChild.AppendChild(head);
                // if you want to add it to every "Engine" node:
                elemList[i].AppendChild(head);
                //doc.Save(filename); 
            }
            // save at the end, when you're done with the document:
            doc.Save(filename); 
