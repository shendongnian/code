    public class DbContextFactory : IDesignTimeDbContextFactory<KuchidDbContext>
    {
       public KuchidDbContext CreateDbContext(string[] args)
       {
           var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
           var dbContextBuilder = new DbContextOptionsBuilder<KuchidDbContext>();
           var connectionString = configuration.GetConnectionString("connectionString");
           var migrationAssemblyName= configuration.GetConnectionString("migrationAssemblyName");
           dbContextBuilder.UseSqlServer(connectionString, o => o.MigrationAssembly(migrationAssemblyName));
           return new KuchidDbContext(dbContextBuilder.Options);
       }
    }
