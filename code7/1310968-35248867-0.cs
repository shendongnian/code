    public class ResponseRoot
    {
       public List<Response> response { get; set; }
    }
    public class Response
    {
        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        [JsonConverter(typeof(SecondsToStringConverter))]
        public string duration { get; set; }
        public string url { get; set; }
        public string lyrics_id { get; set; }
        public int genre { get; set; }
    }
    class SecondsToStringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return $"{(long)reader.Value / 60}:{(long)reader.Value % 60}";
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (int);
        }
    }
