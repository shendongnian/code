    string defaultConString = @"server=.\SQLExpress;Database=CodeFirstDbSample;Trusted_Connection=yes;";
    
    void Main()
    {
        CreateSampleCodeFirstData();
        ListData();
    }
    
    private void CreateSampleCodeFirstData()
    {
     	var ctx = new MyContext(defaultConString);
      for (int i = 0; i < 10; i++)
      {
        var c = new Customer { CustomerName="c" + i };
        ctx.Customers.Add( c );
      }
      
      for (int i = 0; i < 10; i++)
      {
        var p = new Product { ProductName="p" + i };
        ctx.Products.Add( p );
      }
    
      ctx.SaveChanges();
    
      for (int i = 0; i < 10; i++)
      {
        var customer = ctx.Customers.Single (c => c.CustomerName == "c"+i);
        var products = ctx.Products.OrderBy (p => Guid.NewGuid()).Take(3);
        customer.Products = new List<Product>();
        customer.Products.AddRange( products );
      }
    
      ctx.SaveChanges();
    }
    
    private void ListData()
    {
      var ctx = new MyContext(defaultConString);
      Console.WriteLine ("By Customer");
      Console.WriteLine ("".PadRight(50,'-'));
      foreach (Customer c in ctx.Customers.Include("Products"))
      {
        Console.WriteLine ("{0}: {1}", c.CustomerId, c.CustomerName);
        Console.WriteLine ("\t\t{0}", 
          string.Join(",", c.Products.Select (p => p.ProductName)));
      }
      Console.WriteLine ("".PadRight(50,'='));
      Console.WriteLine ();
      
      Console.WriteLine ("By Product");
      Console.WriteLine ("".PadRight(50,'-'));
      foreach (Product p in ctx.Products.Include("Customers"))
      {
        Console.WriteLine ("{0}: {1}", p.ProductId, p.ProductName);
        Console.WriteLine ("\t\t{0}", 
           string.Join(",", p.Customers.Select (c => c.CustomerName) ));
      }
      Console.WriteLine ("".PadRight(50,'='));
      Console.WriteLine ();
    }
    
    public class MyContext : DbContext
    {
      public MyContext(string connectionString)
         : base(connectionString)  {}
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Product> Products { get; set; }
    }
    
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual List<Customer> Customers { get; set; }
    
    }
    
    public class Customer
    {
        public int CustomerId{ get; set; }
        public string CustomerName{ get; set; }
        public virtual List<Product> Products { get; set; }
    }
