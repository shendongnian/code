    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticHttpContext();
            app.UseMvc();
        }
    }
