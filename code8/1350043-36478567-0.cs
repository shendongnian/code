            public Startup(IHostingEnvironment env)
            {
            }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            public void Configure1(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.UseIISPlatformHandler();
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseMvc();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.Map("/LiveValidatedTruckPostings", (app1) => this.Configure1(app1, env, loggerFactory));
            }
    
            // Entry point for the application.
            public static void Main(string[] args) => WebApplication.Run<Startup>(args);
