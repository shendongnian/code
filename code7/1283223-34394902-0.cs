        /// <summary>
        /// Create new node by design
        /// </summary>
        /// <param name="newXmlNode">New xml parrent node</param>
        /// <param name="xmlParrent">Where is add newXmlNode</param>
        /// <param name="childNodes">all child nodes with their values</param>
        public static void CreateDatabaseNode(string newXmlNode, string xmlParrent, Dictionary<string, string> childNodes)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:/VS_Projects/helper/v1.0.1/Growthanalyzer.App/Resources/Settings.xml");
            //doc.Load(@"../../Resources/Settings.xml");
            XmlNodeList nodes = doc.SelectNodes("/Settings/" + xmlParrent);
            
            foreach (XmlNode node in nodes)
            {
                if (node.Name == xmlParrent)
                {
                    XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Database", "");
                    node.AppendChild(newNode);
                    foreach (var child in childNodes)
                    {
                        XmlNode childNode = doc.CreateNode(XmlNodeType.Element, child.Key, "");
                        childNode.InnerText = child.Value;
                        newNode.AppendChild(childNode);
                    }
                    break;
                }
            }
            doc.Save(@"D:/VS_Projects/helper/v1.0.1/Growthanalyzer.App/Resources/Settings.xml");
        }
