    public static class Namespaces
    {
        public const string FSAMarketsFeed = @"http://www.fsa.gov.uk/XMLSchema/FSAMarketsFeed-v1-2";
        public const string FSAFeedCommon = @"http://www.fsa.gov.uk/XMLSchema/FSAFeedCommon-v1-2";
        public static XmlSerializerNamespaces GetFSAMarketsFeedNamespace()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", Namespaces.FSAMarketsFeed);
            return ns;
        }
    }
    public static class XObjectExtensions
    {
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
        public static XDocument SerializeToXDocument<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                serializer = serializer ?? new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj, ns);
            }
            return doc;
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            var doc = obj.SerializeToXDocument(serializer, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
    }
