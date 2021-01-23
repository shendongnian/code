    public class Rootobject
    {
        public Customer[] Customers { get; set; }
    }
    public class Customer
    {
        public string Code { get; set; }
        public string Alpha { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Contact { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
