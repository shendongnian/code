    `public class Foo
    {
        [JsonProperty("one")]
        public string One { get; set; }
        [JsonProperty("two")]
        public string Two { get; set; }
        [JsonProperty("three")]
        public string Three { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("one")]
        public List<Foo> One { get; set; }
        [JsonProperty("two")]
        public List<Foo> Two { get; set; }
    }`
