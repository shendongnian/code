    public class MyContext : DbContext
    {
        public DbSet<Rule> Rules {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OverTimeRule>().ToTable("OverTimeRules");
            ...
        }
    }
