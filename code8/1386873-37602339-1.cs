    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            Database.Initialize(true);
        }
        public DbSet<Wrapper> Wrappers { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
