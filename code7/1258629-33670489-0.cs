    public class QueryFilterDetailDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Context { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> Expression { get; set; }
    }
