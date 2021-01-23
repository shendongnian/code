    public static class XObjectExtensions
    {
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer = null)
        {
            using (var reader = element.CreateReader())
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd attributes.
            return ns;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, NoStandardXmlNamespaces()); // Disable the xmlns:xsi and xmlns:xsd attributes by default.
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializerNamespaces ns)
        {
            return obj.SerializeToXElement(null, ns);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            return obj.SerializeToXElement(serializer, (omitStandardNamespaces ? NoStandardXmlNamespaces() : null));
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
