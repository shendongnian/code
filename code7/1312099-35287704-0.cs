    public class Customer
    {
      [Key]
      public int CustomerId { get; set; }
      ...
      public int? SupportRepId { get; set; }
      [ForeignKey("SupportRepId")]
      public virtual Employee SupportRep { get; set; }
    }
    public class Employee
    {
      [Key]
      public int EmployeeId { get; set; }
      ...
      public virtual ICollection<Customer> Customers { get; set; }
    }
