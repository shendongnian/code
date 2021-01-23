    public class PetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Animal);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            JObject jsonObject = JObject.Load(reader);
            if (jsonObject["Lives"] != null) return jsonObject.ToObject<Cat>(serializer);
            if (jsonObject["StopPhrase"] != null) return jsonObject.ToObject<Parrot>(serializer);
            
            return null;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { 
            throw new NotImplementedException(); 
        }
    }
