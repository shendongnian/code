    using apiservice.Models;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Data.Entity;
    
    
    namespace apiservice
    {
        public class Startup
        {
            public static IConfigurationRoot Configuration {get; set;}
    
            public Startup(IHostingEnvironment env)
            {
                // Set up configuration sources.
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<BookContext>(options => 
                        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
                    );
    
                services.AddMvc();
            }
    
            public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                // we need to execute the following two commands before
    
                //    dnu restore
                //    dnx ef migrations add Initial
                //    dnx ef database update   
    
                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<BookContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
    
                app.UseIISPlatformHandler();
    
                app.UseStaticFiles();
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
    
                SampleData.Initialize(app.ApplicationServices);
            }
    
            // Entry point for the application.
            public static void Main(string[] args) => WebApplication.Run<Startup>(args);
        }
    }
