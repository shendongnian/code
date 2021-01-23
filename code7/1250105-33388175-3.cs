    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                string[] headersToRemove = { "Server" };
                foreach (var header in headersToRemove)
                {
                    if (context.Response.Headers.ContainsKey(header))
                    {
                        context.Response.Headers.Remove(header);
                    }
                }
                await next(); 
            });
        }
    }
