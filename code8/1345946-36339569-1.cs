        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dt = value as DateTime?;
            if (dt.HasValue)
            {
                writer.WriteValue(dt.Value.ToUnixTimestamp());
            }
            else
            {
                writer.WriteNull();
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return GetDefault(objectType);
            }
            var stamp = (long)JToken.Load(reader);
            return stamp.FromUnixTimestamp();
        }
