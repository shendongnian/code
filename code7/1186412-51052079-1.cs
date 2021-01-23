    using Microsoft.Extensions.Configuration;
    public class Startup
    {
        public void Configure(IConfiguration configuration,
                              ... other injected services
                              )
        {
            app.Run(async (context) =>
            {
                string myValue = configuration["MyKey"];
                await context.Response.WriteAsync(myValue);
            });
