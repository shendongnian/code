    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			
            services.AddMvc();
			//services.Configure<ForwardedHeadersOptions>(option => { option.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All; });  // This option should not be used. it gives me 127.0.0.1 if I have used this option.
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
			app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All });
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
