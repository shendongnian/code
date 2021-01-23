    public interface IMyDbContext
    {
        IQueryable<Product> Products { get; }
    }
    public class MyDbContext: DbContext, IMyDbContext
    {
        public DbSet<Product> Products { get; set; }
        IQueryable<Product> IMyDbContext.Products { get { return Products; } }
    }
