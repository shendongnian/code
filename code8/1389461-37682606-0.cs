    public class Partner
    {
        public long Id { get; set; }
        public string NaturalKey { get; set; }
        // foreign key to address
        public long BillingAddressId { get; set; }
        public virtual BillingAddress BillingAddress { get; set; }
        // a partner has a collection of customers:
        public virtual ICollection<Customer> Customers { get; set; }
    }
    public class Customer : IId, ITerminable
    {
        public long Id { get; set; }
        // foreign key to partner:
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        // foreign key to address
        public long BillingAddressId { get; set; }
        public virtual BillingAddress BillingAddress { get; set; }
    }
  
    public class BillingAddress
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Preposition { get; set; }
        public string Surname { get; set; }
        // etc
	}
