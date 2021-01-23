    public static class XmlDocumentExtensions
    {
        public static XElement ToXElement(this XmlDocument xmlDocument)
        {
            if (xmlDocument.DocumentElement == null)
                return null;
            using (var nodeReader = new XmlNodeReader(xmlDocument.DocumentElement))
            {
                return XElement.Load(nodeReader);
            }
        }        
    }
