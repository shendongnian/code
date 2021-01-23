    public class CreateResponse
    {
        // use of JsonPropertyAttribute is supported on properties if needed.
        public bool ok { get; set; }
        public string id { get; set; }
        public string rev { get; set; }
        public string error { get; set; }
        public string reason { get; set; }
    }
