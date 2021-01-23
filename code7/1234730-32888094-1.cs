    public class Periods
    {
        [JsonProperty("0")]
        public Dictionary<string,Period> period { get; set; }
    }
    public class Period
    {
        [JsonProperty("label")]
        public string label { get; set; }
        [JsonProperty("start_date")]
        public string start_date { get; set; }
        [JsonProperty("end_date")]
        public string end_date { get; set; }
    }
