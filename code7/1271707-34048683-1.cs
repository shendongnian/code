    [JsonConverter(typeof(StopConverter))]
    public class Stop
    {
        public decimal Value { get; set; }
        public string Color { get; set; }
    }
