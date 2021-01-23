    public class PlanetRoot
    {
        public Planet[] planet { get; set; }
    }
    public class Planet
    {
        public string id { get; set; }
        public string planetid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Product product { get; set; }
        [JsonProperty("publishedDate")]
        public string publishdate { get; set; }
        [JsonProperty("createdTime")]
        public string createtime { get; set; }
    }
    public class Product
    {
        public string moreid { get; set; }
        public string color { get; set; }
        public string imageUrl { get; set; }
        public Neighbor[] neighbor { get; set; }
        public DateTime estimatedLocationDate { get; set; }
    }
    public class Neighbor
    {
        public string ring { get; set; }
        public int moons { get; set; }
    }
	
