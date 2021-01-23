    using Owin;
    
    namespace WebApplication2
    {
        public class Startup
        {
            public static void Configuration(IAppBuilder app)
            {
                app.Use(async (ctx, next) =>
                {
                    await ctx.Response.WriteAsync("Test");
                });
            }
        }
    }
