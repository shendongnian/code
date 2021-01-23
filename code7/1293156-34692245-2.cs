    public class MyContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ClientEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new JobEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
