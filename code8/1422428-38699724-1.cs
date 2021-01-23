    public class Location
    {
        public IList<Address> Addresses { get; set; }
    }
    public class Address {
        public string AddressName { get; set; }
        [JsonProperty("Name")] # You'll need attributes if the dataset has another name than that of the object's property.
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
