    void Main()
    {
      DataContext db = new DataContext(@"server=.\SQLexpress;trusted_connection=yes;database=Northwind");
      Table<Customer> Customers = db.GetTable<Customer>();
      
      // for LinqPad
      //Customers.Dump();
    
    }
    
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column]
        public string CustomerID { get; set; }
        [Column]
        public string ContactName { get; set; }
        [Column]
        public string CompanyName { get; set; }
    }
