    public class PetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) { return objectType == typeof(Mammal); }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            if (reader.TokenType == JsonToken.StartArray)
            {
                return JArray.Load(reader)
                    .Cast<JObject>()
                    .Select(o => JObjectToMammal(o, serializer))
                    .ToList();
            }
            return JObjectToMammal(JObject.Load(reader), serializer);
        }
        private Mammal JObjectToMammal(JObject jsonObject, JsonSerializer serializer)
        {
            if (jsonObject["Lives"] != null) return jsonObject.ToObject<Cat>(serializer);
            if (jsonObject["Drools"] != null) return jsonObject.ToObject<Dog>(serializer);
            return null;
        }
    }
