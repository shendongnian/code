    public static class XObjectExtensions
    {
        public static T Deserialize<T>(this XContainer element)
        {
            return element.Deserialize<T>(null);
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                serializer = serializer ?? new XmlSerializer(typeof(T));
                object result = serializer.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static XElement SerializeToXElement<T>(this T obj)
        {
            return obj.SerializeToXElement(null, true);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                XmlSerializerNamespaces ns = null;
                if (omitStandardNamespaces)
                    (ns = new XmlSerializerNamespaces()).Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                serializer = serializer ?? new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj, ns);
            }
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
