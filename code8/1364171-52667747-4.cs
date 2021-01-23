    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISeedService, SeedService>();
            services.AddScoped<IDbConfiguration, FakeDbConfiguration>();
            services.AddDbContext<InitializeContext>((provider, builder) =>
            {
                var dbConfiguration = provider.GetService<IDbConfiguration>();
                builder.UseSqlServer(dbConfiguration.Connection);
            });
            // omitted
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // omitted
        }
    }
