    public class Data
    {
        [JsonProperty("series")]
        public IEnumerable<DateTime> Series { get; set; }
        [JsonProperty("values")]
        public IDictionary<string, IDictionary<DateTime, int>> Values { get; set; }
    }
