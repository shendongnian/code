    public class PagedResult<T> where T : class
    {
        [JsonPropertyNameBasedOnItemClassAttribute]
        public List<T> Results { get; set; }
        [JsonProperty("count")]
        public long Count { get; set; }
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }
        [JsonProperty("per_page")]
        public long PerPage { get; set; }
        [JsonProperty("pages")]
        public long Pages { get; set; }
    }
