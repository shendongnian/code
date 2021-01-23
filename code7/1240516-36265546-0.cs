    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("<your connection string>");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ...
        }
    }
