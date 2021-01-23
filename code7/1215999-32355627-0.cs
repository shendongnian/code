    public class FilterResult
    {
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("SalesPersonId")]
        public int? SalesPersonId { get; set; }
        [JsonProperty("Status")]
        public int? Status { get; set; }
        [JsonProperty("NewIncumbent")]
        public bool? NewIncumbent { get; set; }
    }
