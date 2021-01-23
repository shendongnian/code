    namespace WebNotWar
    {
        public class Startup
        {
            public void Configure(IApplicationBuilder app)
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("head, body");
                });
            }
    
            public static void Main(string[] args) => WebApplication.Run(args);
        }
    }
