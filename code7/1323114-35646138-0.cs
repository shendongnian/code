    public class Customer
    {
        public int Id { get; set; }
        public Address { get; set; }
    }
    public class Address
    {
       public int Id { get; set; }
       public int? CustomerId { get; set; }
       public virtual Customer { get; set; }
    }
