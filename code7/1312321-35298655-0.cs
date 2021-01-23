    public static class JsonExtensions
    {
        public static IEnumerable<T> ParseArray<T>(this TextReader textReader)
        {
            using (var reader = new JsonTextReader(textReader))
            {
                bool inArray = false;
                var ser = JsonSerializer.CreateDefault();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.Comment)
                        continue;
                    if (reader.TokenType == JsonToken.StartArray && !inArray)
                    {
                        inArray = true;
                        continue;
                    }
                    if (reader.TokenType == JsonToken.EndArray)
                        break;
                    yield return ser.Deserialize<T>(reader);
                }
            }
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            // This method should be present on JToken but is only present on JContainer.
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { node };
        }
        public static bool IsNumeric(this JTokenType type) { return type == JTokenType.Integer || type == JTokenType.Float; }
        public static bool IsNumeric(this JToken token) { return token == null ? false : token.Type.IsNumeric(); }
    }
