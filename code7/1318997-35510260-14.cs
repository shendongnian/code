    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    
    namespace App04SimpleMiddleware
    {
        public class Startup
        {   
            public void Configure(IApplicationBuilder app)
            {
                app.UseMiddleware<SimpleMiddleware>();            
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello world!");
                });
            }
        }
    }
