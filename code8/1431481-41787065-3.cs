    public class Startup
    {
        private IConfigurationRoot _configuration;
        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(_configuration);
            services.AddDbContext<MyContext>(options => options
                .UseSqlServer(_configuration.GetConnectionString("MyContext")));
        }
    }
