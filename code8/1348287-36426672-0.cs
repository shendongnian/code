    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, n) =>
            {
                if (ctx.Request.Path == new PathString("/path/to/token")) //the same path you specified in the "TokenEndpointPath" property of "OAuthAuthorizationServerOptions"
                {
                    var authHeader = ctx.Request.Headers["Authorization"];
                    if (!string.IsNullOrWhiteSpace(authHeader) && authHeader.StartsWith("Basic "))
                    {
                        //parse here authHeader
                        var name = GetUsernameFromHeader(authHeader);
                        var password = GetPasswordFromHeader(authHeader);
                        //change the above lines with your parsing methods
                        var form = new Dictionary<string, string[]>()
                        {
                            { "grant_type", new [] {"password" }},
                            { "username", new []{ name }},
                            { "password", new [] { password}}
                        };
                        ctx.Set<IFormCollection>("Microsoft.Owin.Form#collection", new FormCollection(form));
                    }
                }
                await n.Invoke();
            });
            //app.UseWebApi... 
            //other middlewares
        }
    }
