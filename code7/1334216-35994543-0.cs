    public class TestFixture : IDisposable
    {
        public IConfigurationRoot Configuration { get; set; }
        public TestFixture()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    
        public void Dispose()
        {
    
        }
    }
