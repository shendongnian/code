    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //other configurations
          
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
    
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    
            try
            {
                //retrieve your user from database. ex:
                var user = await userService.Authenticate(context.UserName, context.Password);
    
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
    
                //roles example
                var rolesTechnicalNamesUser = new List<string>();
    
                if (user.Roles != null)
                {
                    rolesTechnicalNamesUser = user.Roles.Select(x => x.TechnicalName).ToList();
    
                    foreach (var role in user.Roles)
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.TechnicalName));
                }
    
                var principal = new GenericPrincipal(identity, rolesTechnicalNamesUser.ToArray());
    
                Thread.CurrentPrincipal = principal;
    
                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "message");
            }
        }
    }
