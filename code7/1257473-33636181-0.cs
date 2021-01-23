    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public InventoryContext()
        {
          
            foreach (var product in Products)
                product.Categories = Categories.Where(c => c.ID == product.CategoryId).ToList();
        }
    }
