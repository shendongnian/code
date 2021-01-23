    class DataItemConverter: JsonConverter
        {
    
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var di = value as DataItem;
                writer.WriteStartObject();
                writer.WritePropertyName("id");
                writer.WriteValue(di.Id);
                writer.WriteEndObject();
            }
        }
