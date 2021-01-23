        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return GetDefault(objectType);
            }
            var text = (string)JToken.Load(reader);
            return text.FromUnixTimestamp();
        }
