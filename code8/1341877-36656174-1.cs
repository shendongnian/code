    using System;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    
    namespace ServerSentEventSample 
    {
        public class Program
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDirectoryBrowser();
            }
            
            public void Configure(IApplicationBuilder app, IHostingEnvironment host)
            {
                app.UseFileServer(new FileServerOptions
                {
                    EnableDirectoryBrowsing = true
                });
    
                app.Use(async (context, next) =>
                {
                    var path = context.Request.Path.ToString();
                    if (path.Contains("sse"))
                    {
                        context.Response.Headers.Add("Content-Type", "text/event-stream");
                        await context.Response.WriteAsync("data: First message.\r\n");
                        await context.Response.WriteAsync("data: Second message.\r\n");
                        await context.Response.WriteAsync("data: Third message.\r\n\r\n");
                    }
    
                    await Task.Delay(1);
                    return;
                });
            }
    
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
                    .UseStartup<Program>()
                    .Build();
    
                host.Run();
            }
        }
    }
