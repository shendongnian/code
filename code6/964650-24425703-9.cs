    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext(string connectionString)
        {
            // Configure context as you want here
        }
        public DbSet<Product> Products { get; set; }
    }
