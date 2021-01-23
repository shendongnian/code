    public class RootObject
    {
        [JsonProperty("data")]
        public List<Item> Data { get; set; }
    }
    public class Item
    {
        [JsonProperty("address_obj")]
        public Location Location { get; set; }
    }
    public class Location
    {
        [JsonProperty("street1")]
        public string Street1 { get; set; }
        [JsonProperty("street2")]
        public string Street2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postalcode")]
        public string PostalCode { get; set; }
        [JsonProperty("address_string")]
        public string FullAddress { get; set; }
    }
    
