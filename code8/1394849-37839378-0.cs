    public class ApiResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<Dictionary<string, string>> Data;
        [JsonProperty(PropertyName = "error")]
        public IEnumerable<Dictionary<int, string>> Errors;
    };
