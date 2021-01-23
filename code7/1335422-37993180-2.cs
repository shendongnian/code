    public class BsonDocumentJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BsonDocument);
        }
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string json = (value as BsonDocument).ToJson();
            writer.WriteRawValue(json);
        }
    }
