    // message interface
    public interface ITestMessage
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        TestBaseClass Data { get; set; }
    };
