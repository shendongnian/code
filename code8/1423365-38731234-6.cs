    public static class JsonExtensions
    {
        public static void WrapWithObjects(this IEnumerable<JToken> values, string name)
        {
            foreach (var value in values.ToList())
            {
                var newParent = new JObject();
                if (value.Parent != null)
                    value.Replace(newParent);
                newParent[name] = value;
            }
        }
        public static XElement ToXElement(this JObject obj, string deserializeRootElementName = null, bool writeArrayAttribute = false)
        {
            if (obj == null)
                return null;
            using (var reader = obj.CreateReader())
                return JsonExtensions.DeserializeXElement(reader, deserializeRootElementName, writeArrayAttribute);
        }
        static XElement DeserializeXElement(JsonReader reader, string deserializeRootElementName, bool writeArrayAttribute)
        {
            var converter = new Newtonsoft.Json.Converters.XmlNodeConverter() { DeserializeRootElementName = deserializeRootElementName, WriteArrayAttribute = writeArrayAttribute };
            var jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = new JsonConverter[] { converter } });
            return jsonSerializer.Deserialize<XElement>(reader);
        }
    }
