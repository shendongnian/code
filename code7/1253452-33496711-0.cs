    public class Data
    {
        [JsonProperty("product_data")]
        public Dictionary<string, Product> ProductData { get; set; }
        [JsonProperty("product_count_total")]
        public int ProductCountTotal { get; set; }
    }
