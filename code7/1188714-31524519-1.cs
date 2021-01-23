    public class CartModifierSerializer : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var modifier = value as CartModifier;
            writer.WriteStartObject();
            foreach (var pair in modifier.Values)
            {
                writer.WritePropertyName(pair.Key);
                writer.WriteValue(pair.Value);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var properties = jsonObject.Properties().ToList();
            return new CartModifier
            {
                Values = properties.ToDictionary(x => x.Name, x => (long) x.Value)
            };
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(CartModifier).IsAssignableFrom(objectType);
        }
    }
