    public class OptionalBoolConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(OptionalBool) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var converted = (bool?) (OptionalBool) value;
            writer.WriteValue(converted);
        }
    }
