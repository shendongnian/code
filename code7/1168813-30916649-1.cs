    private static IEnumerable<XElement> StreamElements(string fileName, string elementName)
    {
        var settings = new XmlReaderSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment
        };
    
        using (XmlReader reader = XmlReader.Create(fileName, settings))
        {
            reader.MoveToContent();
    
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == elementName)
                    {
                        var el = XNode.ReadFrom(reader) as XElement;
                        if (el != null)
                        {
                            yield return el;
                        }
                    }
                }
            }
        }
    }
