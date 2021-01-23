    public class OrderArchive
    {
       public System.DateTime OrderDate { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public string PostalCode { get; set; }
       public List<OrderDetailArchive> Details { get; set; }
    }
    
    public class OrderDetailsArchive
    {
       public string Title { get; set; }
       public string Description { get; set; }
       public int Quantity { get; set; }
       public decimal UnitPrice { get; set; }
    }
