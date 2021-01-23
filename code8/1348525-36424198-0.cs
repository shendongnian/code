    public class AppDbContext : DbContext
    {
        public AppDbContext(string databaseNameOrConnectionString)
            : base(databaseNameOrConnectionString)
        {
            // This line creates a new database if it does not exist on the database server. 
            // Just ensure that you pass a new name periodically to get a new database.
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }
    // other overloads of the db context, if needed
    }
