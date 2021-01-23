    [JsonConverter(typeof(RequestConverter))]
    public class Request
    {
        public Request() { }
        public EntityObject Entity { get; set; }
    }
