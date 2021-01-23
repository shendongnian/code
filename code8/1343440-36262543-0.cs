    public class Response<T>
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("data")]
        public Data<T> Data { get; set; }
    }
    public class Data<T>
    {
        public T ResponseData { get; set; }
    }
