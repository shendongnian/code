    public class Product
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("items")]
        public Dictionary<string, Item> Items { get; set; }
    }
    public class Item
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
