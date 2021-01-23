     public Startup(IHostingEnvironment env)
     {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
        
      }
      public void ConfigureServices(IServiceCollection services)
      {
            services.AddEntityFramework()
              .AddSqlServer()            
              .AddDbContext<WtContext>(options =>
                 options.UseSqlServer(Configuration["Data:MyDb:ConnectionString"]));
       }
