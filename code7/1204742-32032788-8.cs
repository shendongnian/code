    public class MyContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category > Categories{ get; set; }
        public DbSet<ProductCategoryLink> ProductCategoriesLinks { get; set; }    
    }
