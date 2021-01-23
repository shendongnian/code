    public static class XmlReaderExtensions
    {
        public static IEnumerable<string> ReadChildElementNames(this XmlReader xmlReader)
        {
            if (xmlReader == null)
                throw new ArgumentNullException();
            if (xmlReader.NodeType == XmlNodeType.Element && !xmlReader.IsEmptyElement)
            {
                var depth = xmlReader.Depth;
                while (xmlReader.Read())
                {
                    if (xmlReader.Depth == depth + 1 && xmlReader.NodeType == XmlNodeType.Element)
                        yield return xmlReader.Name;
                    else if (xmlReader.Depth == depth && xmlReader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
        }
        public static bool ReadToFirstElement(this XmlReader xmlReader)
        {
            if (xmlReader == null)
                throw new ArgumentNullException();
            while (xmlReader.NodeType != XmlNodeType.Element)
                if (!xmlReader.Read())
                    return false;
            return true;
        }
    }
