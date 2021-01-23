    public static IEnumerable<XElement> GetElement(this XmlReader reader, string elementName)
    {
        while (!reader.EOF)
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                yield return XNode.ReadFrom(reader) as XElement;
            else
                reader.Read();
    }
