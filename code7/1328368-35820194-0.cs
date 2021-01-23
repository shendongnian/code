    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    
    namespace WebApplication5
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env)
            {
            }
    
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
                services.AddTransient<IStudentDataAccess, StudentDataAccess>();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.UseIISPlatformHandler();
                app.UseMvc();
            }
            public static void Main(string[] args) => WebApplication.Run<Startup>(args);
        }
    }
