    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
        }
    }
