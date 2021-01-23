    public class FlattenJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
                return;
            }
    
            JObject o = (JObject)t;
            writer.WriteStartObject();
            WriteJson(writer, o);
            writer.WriteEndObject();
        }
    
        private void WriteJson(JsonWriter writer, JObject value)
        {
            foreach (var p in value.Properties())
            {
                if (p.Value is JObject)
                    WriteJson(writer, (JObject)p.Value);
                else
                    p.WriteTo(writer);
            }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, 
           object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override bool CanConvert(Type objectType)
        {
            return true; // works for any type
        }
    }
