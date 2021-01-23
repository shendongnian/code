    public class CounterContext : DbContext
    {
        static CounterContext  // runs once
        {
            Database.SetInitializer<CounterContext>(new CreateDatabaseIfNotExists<CounterContext>());
        }
        public CounterContext()
            : base("name=CounterDbString") { }
        public DbSet<CounterData> CounterDetails { get; set; }
        public DbSet<Environment> Environments { get; set; }
    }
