    public class Response<T>
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
