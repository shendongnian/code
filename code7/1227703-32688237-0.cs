    public static IEnumerable<XElement> StreamXmlDoc(Stream inputStream, string nodeName)
    {
        using (var reader = new StreamReader(inputStream))
        {
            using (var xmlReader = XmlReader.Create(reader))
            {
                xmlReader.MoveToContent();
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (xmlReader.Name == nodeName)
                            {
                                var xElement = XElement.ReadFrom(xmlReader) as XElement;
                                if (xElement != null)
                                {
                                    yield return xElement;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
