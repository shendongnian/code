    public class YourDbContext : DbContext
    {
        ...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DefaultConnection");
            base.OnConfiguring(optionsBuilder);
        }
    }
