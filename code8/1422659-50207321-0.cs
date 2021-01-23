    public class DbContextFactory : IDesignTimeDbContextFactory<KuchidDbContext>
    {
        public KuchidDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var dbContextBuilder = new DbContextOptionsBuilder<KuchidDbContext>();
            var connectionString = configuration.GetConnectionString("Kuchid");
            dbContextBuilder.UseSqlServer(connectionString);
            return new KuchidDbContext(dbContextBuilder.Options);
        }
    }
