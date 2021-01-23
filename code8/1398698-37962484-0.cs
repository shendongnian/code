    public class Product
    {
        public string category_id { get; set; }
        [JsonProperty("0")]
        public string Zero { get; set; }
        public string category_name { get; set; }
        [JsonProperty("1")]
        public string One { get; set; }
        public string category_details { get; set; }
        [JsonProperty("2")]
        public string Two { get; set; }
        public string category_link { get; set; }
        [JsonProperty("3")]
        public string Three { get; set; }
    }
