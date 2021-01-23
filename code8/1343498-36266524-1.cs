    public static class JsonMapper
    {
        private static JsonReader CreateReader(string json, string parentToken)
        {
            if (string.IsNullOrEmpty(parentToken))
                return new JsonTextReader(new StringReader(json));
            else
            {
                var token = JToken.Parse(json).SelectToken(parentToken);
                return token == null ? null : token.CreateReader();
            }
        }
        public static T MapFromJson<T>(string json, string parentToken = null)
        {
            var settings = new JsonSerializerSettings { Converters = new [] { new StringEnumConverter() } };
            using (var reader = CreateReader(json, parentToken))
            {
                if (reader == null)
                    return default(T);
                return JsonSerializer.CreateDefault(settings).Deserialize<T>(reader);
            }
        }
    }
