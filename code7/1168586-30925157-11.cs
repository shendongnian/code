    public static class XmlKeyValueListHelper
    {
        public static XElement[] SerializeAttributeNameValueList<T>(IEnumerable<T> items, string nameAttributeName)
        {
            if (items == null)
                return null;
            var ns = new XmlSerializerNamespaces();
            ns.Add("", typeof(T).RootXmlElementNamespace());
            var query = items
                .Select(p => p.SerializeToXElement(ns))
                .Select(e =>
                {
                    var attr = e.Attribute(nameAttributeName);
                    e.Name = e.Name.Namespace + XmlConvert.EncodeLocalName((string)attr);
                    attr.Remove();
                    return e;
                });
            return query.ToArray();
        }
        public static T[] DeserializeAttributeNameValueList<T>(IEnumerable<XElement> elements, string nameAttributeName)
        {
            if (elements == null)
                return null;
            var query = elements
                .Select(e => new XElement(e)) // Do not modify the input values.
                .Select(e =>
                {
                    e.Add(new XAttribute(nameAttributeName, XmlConvert.DecodeName(e.Name.LocalName)));
                    e.Name = e.Name.Namespace + typeof(T).RootXmlElementName();
                    return e;
                })
                .Select(e => e.Deserialize<T>());
            return query.ToArray();
        }
    }
    public static class XmlTypeExtensions
    {
        public static string RootXmlElementName(this Type type)
        {
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                return xmlRoot.ElementName;
            return type.Name;
        }
        public static string RootXmlElementNamespace(this Type type)
        {
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.Namespace))
                return xmlRoot.Namespace;
            return string.Empty;
        }
    }
    public static class XObjectExtensions
    {
        static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, NoStandardXmlNamespaces());
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializerNamespaces ns)
        {
            return obj.SerializeToXElement(null, ns);
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
        public static T Deserialize<T>(this XContainer element)
        {
            return element.Deserialize<T>(new XmlSerializer(typeof(T)));
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                object result = serializer.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
