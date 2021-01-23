    public class AddressValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AddressValue);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var addressValue = (existingValue as AddressValue ?? new AddressValue());
            var token = JObject.Load(reader);
            var property = token.Properties().SingleOrDefault();
            if (property != null)
            {
                addressValue.Label = property.Name;
                addressValue.Value = (string)property.Value;
            }
            return addressValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var addressValue = (AddressValue)value;
            serializer.Serialize(writer, new Dictionary<string, string> { { addressValue.Label, addressValue.Value } });
        }
    }
