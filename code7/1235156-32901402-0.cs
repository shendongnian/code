    void Main()
    {
        const string testJson = "{ \"ip\": \"202.141.243.124\", \"hostname\": \"No Hostname\", \"city\": \"Peshawar\", \"region" +
        "\": \"Khyber Pakhtunkhwa\", \"country\": \"PK\", \"loc\": \"34.0080,71.5785\", \"org\": \"AS92" +
        "60 Multinet Pakistan Pvt. Ltd.\", \"postal\": \"24650\" }";
        
        IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(testJson);
        
    }
    
    
    public class IpInfo
    {
    
        [JsonProperty("ip")]
        public string Ip { get; set; }
    
        [JsonProperty("hostname")]
        public string Hostname { get; set; }
    
        [JsonProperty("city")]
        public string City { get; set; }
    
        [JsonProperty("region")]
        public string Region { get; set; }
    
        [JsonProperty("country")]
        public string Country { get; set; }
    
        [JsonProperty("loc")]
        public string Loc { get; set; }
    
        [JsonProperty("org")]
        public string Org { get; set; }
    
        [JsonProperty("postal")]
        public string Postal { get; set; }
    }
