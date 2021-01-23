    public static class XmlExtensions
    {
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
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
        public static T LoadFromXML<T>(this string xmlString, XmlSerializer serializer = null)
        {
            serializer = serializer ?? new XmlSerializer(typeof(T));
            T returnValue = default(T);
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = serializer.Deserialize(reader);
                if (result is T)
                {
                    returnValue = (T)result;
                }
            }
            return returnValue;
        }
        public static string GetXml<T>(this T obj, XmlSerializerNamespaces ns, bool? standalone)
        {
            return GetXml(obj, null, ns, standalone);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns, bool? standalone)
        {
            serializer = serializer ?? new XmlSerializer(obj.GetType());
            using (var textWriter = new Utf8StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (standalone != null)
                        xmlWriter.WriteStartDocument(standalone.Value);
                    serializer.Serialize(xmlWriter, obj, ns);
                }
                return textWriter.ToString();
            }
        }
    }
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
