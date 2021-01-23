    public static class JsonExtensions
    {
        public static XmlDocument DeserializeXmlNode(JsonReader reader)
        {
            return DeserializeXmlNode(reader, null, false);
        }
        public static XmlDocument DeserializeXmlNode(JsonReader reader, string deserializeRootElementName, bool writeArrayAttribute)
        {
            var converter = new Newtonsoft.Json.Converters.XmlNodeConverter() { DeserializeRootElementName = deserializeRootElementName, WriteArrayAttribute = writeArrayAttribute };
            var jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = new JsonConverter[] { converter } });
            return (XmlDocument)jsonSerializer.Deserialize(reader, typeof(XmlDocument));
        }
    }
