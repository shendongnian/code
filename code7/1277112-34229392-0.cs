    using Microsoft.AspNet.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    
    namespace HelloMvc
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
            {                
                app.UseDeveloperExceptionPage(); // <=== that is missing
    
                app.UseMvcWithDefaultRoute();
            }
        }
    }
