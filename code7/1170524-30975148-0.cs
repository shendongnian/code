    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public virtual Address BillingAddress { get; set; }
        public int BillingAddressId { get; set; }
    }
    public class Address
    {
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public ICollection<Customer> CustomersWhereShipping { get; set; }
        public ICollection<Customer> CustomersWhereBilling { get; set; }
    }
