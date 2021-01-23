    public class MyObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case Newtonsoft.Json.JsonToken.StartArray:
                    return JToken.Load(reader).ToObject<List<object>>(); 
                case Newtonsoft.Json.JsonToken.StartObject:
                    return JToken.Load(reader).ToObject<Dictionary<string, object>>(); 
                default:
                    if (reader.ValueType == null)
                        throw new NotImplementedException("MyObjectConverter");
                    return reader.Value;
            }
        }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((IStringValue)value).StringValue);
        }
    }
