     public class Startup
    {
         public void Configuration(IAppBuilder app)
         {
             AntiForgeryConfig.UniqueClaimTypeIdentifier = Thinktecture.IdentityServer.Core.Constants.ClaimTypes.Subject;
             JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
             app.UseCookieAuthentication(new CookieAuthenticationOptions
             {
                 AuthenticationType = "Cookies"
             });
             var openIdConfig = new OpenIdConnectAuthenticationOptions
             {
                 Authority = "https://localhost:44301/identity",
                 ClientId = "baseballStats",
                 Scope = "openid profile roles baseballStatsApi",
                 RedirectUri = "https://localhost:44300/",
                 ResponseType = "id_token token",
                 SignInAsAuthenticationType = "Cookies",                 
                 UseTokenLifetime = false,
                 Notifications = new OpenIdConnectAuthenticationNotifications
                 {
                     SecurityTokenValidated = async n =>
                     {
                         var userInfoClient = new UserInfoClient(
                                      new Uri(n.Options.Authority + "/connect/userinfo"),
                                      n.ProtocolMessage.AccessToken);
                         var userInfo = await userInfoClient.GetAsync();
                         // create new identity and set name and role claim type
                         var nid = new ClaimsIdentity(
                            n.AuthenticationTicket.Identity.AuthenticationType,
                             Thinktecture.IdentityServer.Core.Constants.ClaimTypes.GivenName,
                             Thinktecture.IdentityServer.Core.Constants.ClaimTypes.Role);
                         userInfo.Claims.ToList().ForEach(c => nid.AddClaim(new Claim(c.Item1, c.Item2)));
                         // keep the id_token for logout
                         nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                         // add access token for sample API
                         nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                         // keep track of access token expiration
                         nid.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));
                         // add some other app specific claim
                         nid.AddClaim(new Claim("app_specific", "some data"));
                         n.AuthenticationTicket = new AuthenticationTicket(
                             nid,
                             n.AuthenticationTicket.Properties);
                         n.Request.Headers.SetValues("Authorization ", new string[] { "Bearer ", n.ProtocolMessage.AccessToken });
                     }
                 }
             };
             app.UseOpenIdConnectAuthentication(openIdConfig);
             app.UseResourceAuthorization(new AuthorizationManager());
             app.Map("/api", inner =>
             {
                 var bearerTokenOptions = new IdentityServerBearerTokenAuthenticationOptions
                 {
                     Authority = "https://localhost:44301/identity",
                     RequiredScopes = new[] { "baseballStatsApi" }
                 };
                 inner.UseIdentityServerBearerTokenAuthentication(bearerTokenOptions);
                 var config = new HttpConfiguration();
                 config.MapHttpAttributeRoutes();
                 inner.UseWebApi(config);
             });                                                 
         }
    }
