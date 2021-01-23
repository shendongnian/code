    public class Corporation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Corporation Corporation { get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
    }
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Factory> Factories { get; set; }
        ...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corporation>().HasMany(c => c.Companies).WithOne(c => c.Corporation);
            modelBuilder.Entity<Company>().HasMany(c => c.Factories).WithOne(c => c.Company);
            modelBuilder.Entity<Factory>().HasOne(f => f.Company);
        }
    }
