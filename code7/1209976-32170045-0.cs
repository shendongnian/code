    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        // Rest of data models
    }
