    public class PeopleDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
        }
    }
