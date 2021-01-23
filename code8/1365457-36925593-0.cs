    public partial class Data
    {
        [JsonProperty("error")]
        public object[] Error { get; set; }
        [JsonProperty("result")]
        public Dictionary<string, object[][]> Result { get; set; }
    }
