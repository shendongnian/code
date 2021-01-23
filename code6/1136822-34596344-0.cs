    public class ContentContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data:DefaultConnection:ConnectionString");
        }
    }
