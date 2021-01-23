    class Employee
    {
        public string name { get; set; }
        [JsonConverter(typeof(IdOnlyListConverter))]
        public ICollection<Address> Addresses { get; set; }
    }
    class Address
    {
        public int id { get; set; }
        public string location { get; set; }
        public string postcode { get; set; }
    }
