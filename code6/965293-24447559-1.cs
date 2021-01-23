    public class IsbnConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Isbn);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var dict = new Dictionary<string, int>();
                serializer.Populate(reader, dict);
                return new Isbn(dict["groupCode"], dict["publisherCode"], dict["titleCode"], dict["checkCode"]);
            }
            if (reader.TokenType == JsonToken.String)
            {
                return new Isbn((string)reader.Value);
            }
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
