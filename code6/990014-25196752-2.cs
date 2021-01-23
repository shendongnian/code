    public class JsonTestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonTestObject).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Is it an array?
            var token = reader.TokenType;
            if (token == JsonToken.StartArray)
            {
                var array = JArray.Load(reader);
                return new JsonTestResultArray(array);
            }
            
            var item = JObject.Load(reader);
            return item.ToObject<JsonTestResultValue>();
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
