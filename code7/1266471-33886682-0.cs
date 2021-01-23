    class Planet
        {
            [JsonProperty("planet")]
            PlanetInfo[] planet { get; set; }
        }
        class Product
        {
            [JsonProperty("estimatedLocationDate")]
            string estimatedLocationDate {get;set;}
        }
        class PlanetInfo
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
    
            [JsonProperty("product")]
            public Product product { get; set; }
        }
