    public static class XmlHelper
    {
        public static T DeserializeFromXmlString<T>(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof (T));
            using (var stringReader = new StringReader(xml))
            {
                return (T) xmlSerializer.Deserialize(stringReader);
            }
        }
        public static T DeserializeFromXmlFile<T>(string filename) where T : new()
        {
            return DeserializeFromXmlString<T>(File.ReadAllText(filename));
        }
    }
