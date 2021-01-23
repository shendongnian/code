    class JsonDataConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);
            if (token is JArray)
                return new Data(token.Select(t => t["prop"].ToString()));
            if (token is JObject)
                return new Data(new[] { token["prop"].ToString() });
            throw new NotSupportedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    [JsonConverter(typeof(JsonDataConverter))]
    class Data:List<string>
    {
        public Data() : base() { }
        public Data(IEnumerable<string> data) : base(data) { }
    }
    class Response
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }
