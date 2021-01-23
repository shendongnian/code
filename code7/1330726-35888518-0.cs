    class DictionaryRegexReplaceJsonConverter : JsonConverter
    {
        public Regex ReplacingRegex { get; set; }
        public string Replacement { get; set; }
        public DictionaryRegexReplaceJsonConverter(Regex replacingRegex, string replacement = "")
        {
            ReplacingRegex = replacingRegex;
            Replacement = replacement;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JToken.ReadFrom(reader);
            foreach (JToken token in jo.ToList())
            {
                string replacedName = ReplacingRegex.Replace(token.Path, Replacement);
                JProperty newToken = new JProperty(replacedName, token.First);
                token.Replace(newToken);
            }
            return jo.ToObject(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
