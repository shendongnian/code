    public class Customer
    {
      public Customer()
      {
        Products = new HashSet<Product>();
      }
      public int Id { get; set; }
      public string Name { get; set; }
    
      public virtual ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
      public int Id { get; set; }
      public int CustomerId { get; set; }
      public string ProductName { get; set; }
    
      public virtual Customer Customer { get; set; }
    }
