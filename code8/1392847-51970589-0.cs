    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    namespace MyApp
    {
        public class Startup
        {
            // ... (only relevant code included) ...
    
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<MyAppContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("MyAppContext")));
                // ...
            }
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<MyAppContext>();
                    context.Database.Migrate();
                }
                // ...
            }
        }
    }
