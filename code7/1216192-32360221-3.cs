    public interface IMyDbContext
    {
        DbSet<Product> Products { get; set; }
        void SaveChanges();
    }
