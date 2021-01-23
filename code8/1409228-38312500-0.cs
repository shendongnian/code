    public sealed class Position
    {
        [JsonProperty("@MMSI")]
        public string MMSI { get; set; }
        [JsonProperty("@LAT")]
        public string Latitude { get; set; }
        [JsonProperty("@LON")]
        public string Longitude { get; set; }
        [JsonProperty("@SPEED")]
        public string Speed { get; set; }
        [JsonProperty("@HEADING")]
        public string Heading { get; set; }
        [JsonProperty("@COURSE")]
        public string Course { get; set; }
        [JsonProperty("@STATUS")]
        public string Status { get; set; }
        [JsonProperty("@TIMESTAMP")]
        public string TimeStamp { get; set; }
    }
