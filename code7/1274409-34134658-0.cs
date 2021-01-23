    public class ProductContext : DbContext
    {
    public ProductContext() : base("WingtipToys")
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    }
    protected override void Seed(ProductContext context)
    {
        GetCategories().ForEach(c => context.Categories.Add(c));// <-here
        GetProducts().ForEach(p => context.Products.Add(p));    // <-here
    }
