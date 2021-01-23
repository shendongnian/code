    public class Location
    {
        public IList<Address> Addresses { get; set; }
    }
    public class Address {
        public string AddressName { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
