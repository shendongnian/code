    public class Startup
    {
        public Startup(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            // Expose the injected instance locally so we populate our settings instance
            _configuration = configuration;
        }
...
