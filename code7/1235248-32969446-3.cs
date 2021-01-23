    public static class XmlSerializationHelper
    {
        public static T LoadFromXML<T>(this string xmlString, XmlSerializer serializer = null)
        {
            T returnValue = default(T);
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                {
                    returnValue = (T)result;
                }
            }
            return returnValue;
        }
        public static string GetXml<T>(this T obj, XmlSerializerNamespaces ns = null, XmlWriterSettings settings = null, XmlSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                settings = settings ?? new XmlWriterSettings() { Indent = true, IndentChars = "  " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (serializer ?? new XmlSerializer(typeof(T))).Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
    }
