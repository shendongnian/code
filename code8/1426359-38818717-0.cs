    public class token
    {
        public DateTime expires { get; set; }
        public string id { get; set; }
        [JsonProperty("RAX-AUTH:authenticatedBy")]
        public string authenticatedBy { set; get; }
    }
