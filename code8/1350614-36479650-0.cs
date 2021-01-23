    class JsonWhoisResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(JsonWhoisResult));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            JsonWhoisResult result = new JsonWhoisResult();
            result.stats = array[0].ToObject<stats>();
            result.header = array[1].ToObject<header>();
            result.datetime = array[2].ToString();
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
