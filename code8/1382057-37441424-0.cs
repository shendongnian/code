    public class MyContext: DbContext{
        public MyContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
        }
    
        public DbSet<Product> Products { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int rating { get; set; }
    }
    internal sealed class Configuration : DbMigrationsConfiguration<MockApplicationUser.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            var dbMigrator = new DbMigrator(this);
            // This is required to detect changes.
            var pendingMigrationsExist = dbMigrator.GetPendingMigrations().Any();
            if (pendingMigrationsExist)
            {
                dbMigrator.Update();
            }
        }
        protected override void Seed(MockApplicationUser.MyContext context)
        {
            Product[] products = new Product[] { new Product { Name = "Product1", rating = 1 }, new Product { Name = "Product1", rating = 1 }, new Product { Name = "Product1", rating = 1 } };
            context.Products.AddOrUpdate(products);
        }
    }
