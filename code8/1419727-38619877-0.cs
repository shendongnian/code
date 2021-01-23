            public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<WorldContext>();
            services.AddLogging();
            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<IMailService, MailServiceDebug>();
            services.AddScoped<IWorldRepository, WorldRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, WorldContextSeedData seeder, IWorldRepository worldRepo)
        {
            string basePath = Startup.Configuration["Data:LogFilePath"];
            loggerFactory.AddProvider(new LoggerFileProvider(basePath));
            loggerFactory.AddProvider(new LoggerDatabaseProvider(worldRepo));
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "index" }
                    );
            });
            seeder.EnsureSeedData();
        }
