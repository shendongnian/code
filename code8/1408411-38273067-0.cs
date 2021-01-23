        public Startup()
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<MyDbContext>(
                options => options.UseSqlServer(Configuration["database:connection"]));
         }
