    public class Planet  
    {
		public string id { get; set; }
		public string name { get; set; }
		[JsonProperty("publishedDate")]
		public string publishdate { get; set; }
		[JsonProperty("estimatedLaunchDate")]
		public string estimatedLaunchDate { get; set; }
		[JsonProperty("createdTime")]
		public string createtime { get; set; }
		[JsonProperty("lastUpdatedTime")]
		public string lastupdate { get; set; }
        public Product product { get; set; }
    }
    public class Product 
    {
        public DateTime estimatedLocationDate { get; set; }
        /* Other members, if necessary */
    }
    string result = JsonConvert.DeserializeObject<Planet>(jsonString).product.estimatedLocationDate;
