    public class DeviceRepositoryTests : IClassFixture<DatabaseFixture>, IDisposable
    {
        private readonly DeviceDbContext _dbContext;
        private readonly DeviceRepository _repository;
        private readonly ITestOutputHelper _output;
        DatabaseFixture _dbFixture;
        public DeviceRepositoryTests(DatabaseFixture dbFixture, ITestOutputHelper output)
        {
            this._dbFixture = dbFixture;
            this._output = output;
            var dbOptBuilder = GetDbOptionsBuilder();
            this._dbContext = new DeviceDbContext(dbOptBuilder.Options);
            this._repository = new DeviceRepository(_dbContext);
            DeviceDbContextSeed.EnsureSeedDataForContext(_dbContext);
            //_output.WriteLine($"Database: {_dbContext.Database.GetDbConnection().Database}\n" +
            _output.WriteLine($"" +
                  $"Locations: {_dbContext.Locations.Count()} \n" +
                  $"Devices: {_dbContext.Devices.Count()} \n" +
                  $"Device Types: {_dbContext.DeviceTypes.Count()} \n\n");
            //_output.WriteLine(deviceDbContextToString(_dbContext));
        }
        public void Dispose()
        {
            _output.WriteLine($"" +
                              $"Locations: {_dbContext.Locations.Count()} \n" +
                              $"Devices: {_dbContext.Devices.Count()} \n" +
                              $"Device Types: {_dbContext.DeviceTypes.Count()} \n\n");
            _dbContext.Dispose();
        }
        private static DbContextOptionsBuilder<DeviceDbContext> GetDbOptionsBuilder()
        {
            // The key to keeping the databases unique and not shared is 
            // generating a unique db name for each.
            string dbName = Guid.NewGuid().ToString();
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DeviceDbContext>();
            builder.UseInMemoryDatabase(dbName)
                   .UseInternalServiceProvider(serviceProvider);
            return builder;
        }
