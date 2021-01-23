    public class Response<T> : Response
    {
        [JsonPropertyGenericTypeName(0)]
        public T Data { get; set; }
    }
