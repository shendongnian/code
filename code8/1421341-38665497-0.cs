    public class ItemRecords
    {
        [JsonProperty("property1")]
        public int Property1 { get; set; }  
        [JsonProperty("property2")]
        public int Property2 { get; set; }  
        [JsonProperty("item_record")]
        public List<ItemRecord> Records { get; set; } 
    }
