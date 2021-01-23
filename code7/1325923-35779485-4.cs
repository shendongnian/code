    public class Startup
    {
    public static void Configuration(IAppBuilder app)
    {
        app.UseOAuthBearerAuthentication(
                      new OAuthBearerAuthenticationOptions());
        app.UseOAuthAuthorizationServer(
                      new OAuthAuthorizationServerOptions
                      {
                          TokenEndpointPath = new PathString("/Token"),
                          Provider = new OAuthAuthorizationServerProvider()
                          {
                              OnValidateClientAuthentication = async c =>
                              {
                                  c.Validated();
                              },
                              OnGrantResourceOwnerCredentials = async c =>
                              {
                               //Add a string with the current date
                                string dateNow = DateTime.UtcNow.ToString();
                                  if (c.UserName == "alice" && c.Password == "supersecret")
                                  {
                                      Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                                      Claim[] claims = new Claim[] { claim1 };
                                      ClaimsIdentity claimsIdentity =
                                          new ClaimsIdentity(
                                             claims, OAuthDefaults.AuthenticationType);
                                      //Add a claim with the creationdate of the token
                                      claimsIdentity.AddClaim(new Claim("creationDate", dateNow));
                                      c.Validated(claimsIdentity);
                                  }
                              }
                          },
                          AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(40),
                          AllowInsecureHttp = true,
                          RefreshTokenProvider = new ApplicationRefreshTokenProvider()
                      });
    }
    }
