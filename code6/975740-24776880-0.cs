    class MyCustomInt32ArrayConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            Object existingValue,
            JsonSerializer serializer)
        {
            var array = serializer.Deserialize(reader) as JArray;
            if (array != null)
            {
                return array.Where(token => token.Type == JTokenType.Integer).Select(token => token.Value<int>()).ToArray();
            }
            return new int[0];
        }
        
        public override void WriteJson(
            JsonWriter writer,
            Object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
