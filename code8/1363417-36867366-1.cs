    [JsonConverter(typeof(YourSerializer))]
    public class YourClassName
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
