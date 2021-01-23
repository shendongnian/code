    public class Dither
    {
        [JsonProperty("method", Order = 1)]
        public string Method { get; set; }
    
        [JsonProperty("params", Order = 2)]
        public ArrayList Parameters { get; set; }
    
        [JsonProperty("id", Order = 3)]
        public int Id { get; set; }
    }
    
    public class Settle
    {
        [JsonProperty("pixels")]
        public double Pixels { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("timeout")]
        public int Timeout { get; set; }
    }
