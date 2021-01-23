        public class ProductContext : DbContext 
    { 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; } 
    }
    
    using (var context = new ProductContext()) 
    {     
        // Perform data access using the context 
    }
