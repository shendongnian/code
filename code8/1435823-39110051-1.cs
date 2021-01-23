    public class LineupConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Lineup);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartObject)
                throw new Exception("Expected an object");
            var jObject = (JObject)JObject.ReadFrom(reader);
            // I suspect the property name are the same as the id property
            // of the contained objects. Discarding the information from serialization
            var players = jObject.Properties()
                .Select(p => p.Value.ToObject<Player>());
            return new Lineup
            {
                Players = players.ToList()
            };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
