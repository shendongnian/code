    [Table] 
    public class Customer
    {
       [Column(IsPrimaryKey=true)]  
       public int ID;
       [Column]                     
       public string Name;
    }
    public class DemoDataContext : DataContext
    {
      public DemoDataContext (string cxString) : base (cxString) { }
    
      public Table<Customer> Customers { get { return GetTable<Customer>(); } }
      public Table<Purchase> Purchases { get { return GetTable<Purchase>(); } }
    }
