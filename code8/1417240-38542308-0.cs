    public class MOBAUTHRequest
    {
        //Request:
        [JsonProperty("Row")]
        public List<Row> Row { get; set; }    
    }
    public class MOBAUTHResponse
    {
        //Request:
        [JsonProperty("Row")]
        public Row Row { get; set; }
    }
