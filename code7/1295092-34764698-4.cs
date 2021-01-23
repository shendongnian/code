    public class Startup
    {
        // property for holding configuration
        public IConfigurationRoot Configuration { get; set; }
    
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                .AddEnvironmentVariables();
            // save the configuration in Configuration property
            Configuration = builder.Build();
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<MyDbContext>(options => {
                    options.UseSqlServer(Configuration["ConnectionString"]);
                });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ...
        }
    }
