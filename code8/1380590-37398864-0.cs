    static void Main(string[] args)
    {
        CreateAndSeedTheDatabase(); // Step 1: run this
        //UpdateAllOfTheProducts(); // Step 2: Comment out the above line and uncomment and run this line
    }
    static void CreateAndSeedTheDatabase()
    {
        Context context = new Context();
        context.Database.Initialize(true);
        Product product;
        for (int i = 0; i < 1000; i++)
        {
            product = new Product() { ProductId = i, Name = "Product" + i };
            context.Products.Add(product);
        }
        context.SaveChanges();
    }
    static void UpdateAllOfTheProducts()
    {
        Context context = new Context();
        Product[] products = context.Products.ToArray();
        foreach (Product product in products)
        {
            product.Name = product.ProductId + "Product";
        }
        context.SaveChanges();
    }
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<Product> Products { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    
}
