    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                var jwt = ctx.Request.Query.Get("jwt");
                if (jwt != null)
                {
                    var userValidationResult = await Utility.ValidateUser(jwt);
                    if (userValidationResult.Validated)
                    {
                        var identity = new ClaimsIdentity("jwt");
                        foreach(var role in userValidationResult.Roles)
                            identity.AddClaim(new Claim(ClaimTypes.Role, role));
                        identity.AddClaim(new Claim(ClaimTypes.Email, userValidationResult.Email));
                        //etc... add every claim
                        ctx.Request.User = new ClaimsPrincipal(identity);
                    }
                }
                await next.Invoke();
            });
            var config = new HttpConfiguration();
            app.UseWebApi(config);
            
            //etc...
        }
    }
