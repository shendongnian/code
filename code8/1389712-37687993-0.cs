    public class Test
    {
        [JsonProperty("id")]
        public string TestId { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("dictionary")]
        public List<TestInnerItem> dictionary { get; set; }
    }
    public class TestInnerItem
    {
        public string Obj { get; set; }
    
        public List<TestInnerInnerItem> List { get; set; }
    }
    
    public class TestInnerInnerItem
    {
        public string Id { get; set; }
    }
