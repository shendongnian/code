      public class PeriodsModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("periods")]
        public Dictionary<string,Period> { get; set; }
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
