    public class Startup
    {
        private readonly IHostingEnvironment _currentEnvironment;
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _currentEnvironment = env;
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ......
            services.AddMvc(config =>
            {
                // Requiring authenticated users on the site globally
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                // Validate anti-forgery token globally
                config.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                // If it's Production, enable HTTPS
                if (_currentEnvironment.IsProduction())      // <------
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }            
            });
            ......
        }
    }
