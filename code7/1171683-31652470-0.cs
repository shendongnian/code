    internal class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
    }
