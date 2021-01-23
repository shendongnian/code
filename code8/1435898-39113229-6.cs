    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			
            services.AddMvc();
			services.Configure<ForwardedHeadersOptions>(option => { option.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders..XForward‌​edFor; });  
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
			//app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All });
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
