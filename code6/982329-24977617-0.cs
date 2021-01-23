    public class Address
    {
        [JsonProperty("Id")]
        public int I'd { get; set; }
        [JsonIgnore]
        public string Location { get; set; }
        [JsonIgnore]
        public string PostalCode { get; set; }
    }
