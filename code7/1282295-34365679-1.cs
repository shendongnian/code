    using System.Reflection;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.DependencyInjection;
    using StructureMap;
    using StructureMap.Graph;
    
    namespace HelloWorldWebApplication
    {
        public class Startup
        {
            public IServiceCollection ConfigureServices(IServiceCollection services)
            {
                var container = new Container();
                container.Configure(x => {
                    x.Scan(scanning => {
                        scanning.Assembly(typeof(Startup).GetTypeInfo().Assembly);
                        scanning.TheCallingAssembly();
                        scanning.WithDefaultConventions();
                    });
                });
                container.Populate(services);
                return container.GetInstance<IServiceCollection>();
            }
    
            public void Configure(IApplicationBuilder app)
            {
                app.UseIISPlatformHandler();
                app.Run(async context => {
                    await context.Response.WriteAsync("Hello World!");
                });
            }
    
            public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
        }
    }
