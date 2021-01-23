    public class ResponseResult
    {
        [JsonProperty("response")]
        public bpResponse Response { get; set; }
    }
    public class bpResponse
    {
        [JsonProperty("success")]
        public string Success { get; set; }
        [JsonProperty("items")]
        public Item Items { get; set; }
    }
    public class Item
    {
        [JsonProperty("Items 1's name")]
        public ItemFirstName ItemFirstName { get; set; }
    }
    public class ItemFirstName
    {
        [JsonProperty("index")]
        public List<string> Index { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("1")]
        public First First { get; set; }
    }
    public class First
    {
        [JsonProperty("special1")]
        public Special1 Special1 { get; set; }
    }
    public class Special1
    {
        [JsonProperty("special2")]
        public List<Special2> Special2 { get; set; }
    }
    public class Special2
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
