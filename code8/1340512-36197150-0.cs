        public class EventResult
        {
        [JsonProperty(PropertyName = "event")]
        public Event Event { get; set; }
        [JsonProperty(PropertyName = "marketCount")]
        public int MarketCount { get; set; }
        }
