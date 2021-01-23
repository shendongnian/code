    public static class XmlSerializationHelper
    {
        public static T LoadFromXML<T>(this string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
        public static string GetXml<T>(this T obj, bool omitStandardNamespaces = false)
        {
            XmlSerializerNamespaces ns = null;
            if (omitStandardNamespaces)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            }			
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
    }
