    class Location
    {
    
       public string ID { get; set; }
       public string Description { get; set; }
    }
    
    class JSONResponse
    {
    
        [JsonProperty("error")]
        public bool Error { get; set; }
    
        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    
    }
