    class KeyValuePairConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, 
                                                          JsonSerializer serializer)
        {
            var list = value as List<KeyValuePair<string, string>>;
            writer.WriteStartArray();
            foreach (var item in list)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(item.Key);
                writer.WriteValue(item.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType,
                                                           object existingValue,
                                                           JsonSerializer serializer)
        {
            // TODO...
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<KeyValuePair<string, string>>);
        }
    }
