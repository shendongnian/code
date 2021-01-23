    public static IEnumerable<XElement> GetElement(this XmlReader reader, string elementName)
    {
        reader.MoveToElement();
    
    	reader.Read();
        while (!reader.EOF)
        {
            if (reader.NodeType == XmlNodeType.Element 
                && reader.Name.Equals(elementName, StringComparison.InvariantCulture))
            {
                yield return XNode.ReadFrom(reader) as XElement;
            }
    		else
            {
                reader.Read();
            }
        }
    }
