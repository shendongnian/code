    public static class XmlExtensions
    {
        public static T DeserializeXml<T>(this string xmlString)
        {
            using (var reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
    }
