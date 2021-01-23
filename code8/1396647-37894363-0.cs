    public class RootObject
    {
        [JsonProperty("Sheet1")]
        public Sheet1[] Sheet1 { get; set; }
    }
    public class Sheet1
    {
        [JsonProperty("one")]
        public int Col1 { get; set; }
        [JsonProperty("two")]
        public int Col2 { get; set; }
    }
    var res = JsonConvert.DeserializeObject<RootObject>(s);
