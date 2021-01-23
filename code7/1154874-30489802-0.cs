    class Program
    {
        static void Main(string[] args)
        {
            var xmlRoot = new XElement(XName.Get("root", "http://somenamespace"));
            xmlRoot.SetAttributeValue("xmlns", "http://somenamespace");
            var xmlDocument = new XDocument(xmlRoot);
            var xmlNamespace = xmlDocument.Root.GetDefaultNamespace().NamespaceName;
        }
    }
