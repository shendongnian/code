    internal sealed class FakeDbConfiguration : IDbConfiguration
    {
        private readonly IConfiguration _configuration;
        public FakeDbConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // REPLACE THIS PART WITH YOURS IMPLEMENTATION
        public string Connection => _configuration["Database:Connection"];
