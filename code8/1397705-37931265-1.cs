    [JsonConverter(typeof(LinksResultConverter))]
    public class LinksResult
    {
        public List<LinkData> Links { get; set; }
        public int Count { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
