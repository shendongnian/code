    public class MyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            List<KeyValuePair<string, object>> list = value as List<KeyValuePair<string, object>>;
            writer.WriteStartArray();
            foreach (var item in list)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(item.Key);
                // Needed because of the dynamic object.
                var jsonValue = JsonConvert.SerializeObject(item.Value);
                writer.WriteValue(jsonValue);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<KeyValuePair<string, object>>);
        }
    }
