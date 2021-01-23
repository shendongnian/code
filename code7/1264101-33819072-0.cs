    public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
                {
                    Provider = new ApplicationOAuthBearerAuthenticationProvider(),
                });
                app.UseJwtBearerAuthentication(JwtOptions());
                
                ConfigureAuth(app);
            }
    
    
            private static JwtBearerAuthenticationOptions JwtOptions()
            {
                var key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["auth:key"]);
                var jwt = new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = Some Audience,
                        ValidIssuer = Some Issuer,
                        IssuerSigningToken = new BinarySecretSecurityToken(key),
                        RequireExpirationTime = false,
                        ValidateLifetime = false
                    }
                };
                return jwt;
            }
    
            public class ApplicationOAuthBearerAuthenticationProvider
                : OAuthBearerAuthenticationProvider
            {
    
                public override Task RequestToken(OAuthRequestTokenContext context)
                {
                    if (context == null)
                        throw new ArgumentNullException("context");
    
                    var token = HttpContext.Current.Request.QueryString["token"];
                    if (!string.IsNullOrEmpty(token))
                        context.Request.Headers.Add("Authorization", new[] { string.Format("Bearer {0}", token) });
                    return Task.FromResult<object>(null);
                }
            }
        }
