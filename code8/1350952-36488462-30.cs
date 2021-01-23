    public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddEntityFramework()
			.AddSqlite()
			.AddDbContext<MyDbContext>();
        }
