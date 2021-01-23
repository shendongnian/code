    public static class XObjectExtensions
    {
        public static XElement SerializeToXElement<T>(this IDictionary<string, T> collection, string collectionName)
        {
            return new XElement(collectionName, collection.Select(x => new XElement("Item", new XAttribute("Object", x.Key), x.Value.SerializeToXElement().Elements())));
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(new XmlSerializer(obj.GetType()), true);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                XmlSerializerNamespaces ns = null;
                if (omitStandardNamespaces)
                    (ns = new XmlSerializerNamespaces()).Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                serializer.Serialize(writer, obj, ns);
            }
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
