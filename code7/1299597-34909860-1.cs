    public class Item
    {
        [JsonMergeKey]
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
