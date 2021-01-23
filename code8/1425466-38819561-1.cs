    [JsonConverter(typeof(JsonAnyPropertyNameConverter))]
    public class ResponseData<T>
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        [JsonAnyPropertyName]
        public List<T> Data { get; set; }
    }
    public class Response
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class Response<T> : Response
    {
        [JsonProperty("data")]
        public ResponseData<T> Data { get; set; }
    }
