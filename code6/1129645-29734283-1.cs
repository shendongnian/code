    [JsonConverter(typeof(JsonDataConverter))]
    public sealed class Data
    {
        public string Name { get; set; }
        public DataResponse DataResponse { get; set; }
    }
