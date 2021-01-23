    private static void RemoveElementWithXDocument(string xmlFile, string nodeName, string elementName, string elementAttribute)
        {
            XDocument xDocument = XDocument.Load(xmlFile);
            try
            {
                foreach (XElement profileElement in xDocument.Descendants(nodeName))
                {
                    if (profileElement.Element(elementName).Value == elementAttribute)
                    {
                        profileElement.Remove();
                    }
                }
                xDocument.Save(xmlFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
