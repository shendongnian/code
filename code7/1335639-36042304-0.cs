    using Microsoft.Owin;
    using Microsoft.Owin.Hosting;
    using Owin;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace StackOverflowAnswer
    {
        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.Use<RespondToRequestMiddleware>();
                // app.UseFileServer for static files like HTML/CSS/JS, from NuGet Microsoft.Owin.StaticFiles
                // etc.
            }
        }
    
        class RespondToRequestMiddleware : OwinMiddleware
        {
            public RespondToRequestMiddleware(OwinMiddleware next)
                : base(next)
            {
    
            }
    
            public async override Task Invoke(IOwinContext context)
            {
                // Perform request stuff...
                // Could verify that the request Content-Type == application/json
                // Could verify that the request method was POST.
                string test;
                using (StreamReader reader = new StreamReader(context.Request.Body))
                {
                    test = await reader.ReadToEndAsync();
                }
    
                await Next.Invoke(context); // pass off request to the next middleware; this is optional.    
                // Perform response stuff...
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(test);
                Console.WriteLine("Response given to a request.");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://localhost:5000/";
                using (WebApp.Start<Startup>(url))
                {
                    Console.WriteLine($"Listening on {url}...");
                    Console.ReadLine(); // keep console from closing so server can keep listening.
                }
            }
        }
    }
