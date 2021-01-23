    public static class JsonExtensions
    {
        public static IEnumerable<T> DeserializeValues<T>(Stream stream)
        {
            var reader = new StreamReader(stream); // Caller should dispose
            return DeserializeValues<T>(reader);
        }
        public static IEnumerable<T> DeserializeValues<T>(TextReader textReader)
        {
            var ser = JsonSerializer.CreateDefault();
            var reader = new JsonTextReader(textReader); // Caller should dispose
            reader.SupportMultipleContent = true;
            while (reader.Read())
            {
                if (reader.Depth > 0
                    && reader.TokenType != JsonToken.None && reader.TokenType != JsonToken.Undefined && reader.TokenType != JsonToken.PropertyName)
                {
                    yield return ser.Deserialize<T>(reader);
                }
            }
        }
    }
