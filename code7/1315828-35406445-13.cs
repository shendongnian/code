    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
    public class StoreContext : DbContext  
    { 
        public DbSet<Category> Categories{ get; set; } 
        public DbSet<Product> Products { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            // optionally, even EF can follow convention and detect 1-m relationship between product and category. 
            modelBuilder.Entity<Product>().HasRequired(p => p.Category) 
                .WithMany(c => c.Products) 
                .HasForeignKey(p => p.CategoryId);
        }
    }
