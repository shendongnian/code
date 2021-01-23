    public class Token
    {
        public DateTime expires { get; set; }
        public string id { get; set; }
        [JsonProperty("RAX-AUTH:authenticatedBy")]
        public IEnumerable<string> authenticatedBy { get; set; }
    }
