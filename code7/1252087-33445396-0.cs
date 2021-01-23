    public class Customer
    {
        // [Key] is implicit by convention
        public int CustomerID { get; set; }
        public string Name { get; set; }
    }
    
    public class Order
    {
        // [Key] is implicit by convention
        public int OrderID { get; set; }
        public DateTime SubmittedDate { get; set; }
        // [ForeignKey("Customer")] is implicit by convention
        public int CustomerID{ get; set; }
        public virtual Customer Customer { get; set; }
    }
