    public class MyObject
    {
        [JsonConverter(typeof(LiteralStringConverter))]
        public string A { get; set; }
        public object B;
    }
