    class Response
    {
            [JsonProperty("result_set")]
            public List<Items> ResultSet { get; set; }
    }
    
    class Items{
         [JsonProperty("P1")]
         public string P1 { get; set; }
         [JsonProperty("P2")]
         public int P2 { get; set; }
    }
