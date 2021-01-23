    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace WebApplication17
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(); 
                services.AddSession(); // problem and solution is here
                services.AddCaching(); // problem and solution is here
               
            }
            
            public void Configure(IApplicationBuilder app)
            {
                app.UseDeveloperExceptionPage(); thanks Maxime Rouiller.
                app.UseSession(); // problem and solution is here
                app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=Index}"));
            }
            
            public static void Main(string[] args) => WebApplication.Run<Startup>(args);
        }
    }
