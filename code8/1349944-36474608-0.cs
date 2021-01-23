    private static void RemoveElementWithXmlDocument(string xmlFile, string nodeName, string elementName, string elementAttribute)
        {
            xDoc.Load(xmlFile);
            try
            {
                foreach (XmlNode node in xDoc.SelectNodes(nodeName))
                {
                    if (node.SelectSingleNode(elementName).InnerText == elementAttribute)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
                xDoc.Save(xmlFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
