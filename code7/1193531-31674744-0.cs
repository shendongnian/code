    public class WeekArray2
        {
    
            [JsonProperty("id")]
            public int id { get; set; }
    
            [JsonProperty("time")]
            public string[] time { get; set; }
    
            [JsonProperty("index")]
            public int index { get; set; }
    
            [JsonProperty("picked")]
            public Picked2[] picked { get; set; }
        }
    
    
        public class MS
        {
    
            [JsonProperty("year")]
            public string year { get; set; }
    
            [JsonProperty("month")]
            public string month { get; set; }
    
            [JsonProperty("currentmonth")]
            public string currentmonth { get; set; }
    
            [JsonProperty("community")]
            public string community { get; set; } 
    
            [JsonProperty("WeekArray")]
            public WeekArray2[] weekarray { get; set; }
        }
