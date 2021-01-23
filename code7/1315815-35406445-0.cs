    public class StoreContext : DbContext  
    { 
        public DbSet<Category> Categories{ get; set; } 
        public DbSet<Product> Products { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Product>().HasRequired(p => p.Category) 
                .WithMany(b => b.Products) 
                .HasForeignKey(p => p.CategoryId);
        }
    }
