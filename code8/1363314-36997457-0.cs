    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNetIdentity.WebApi.Providers;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Infrastructure;
    using Microsoft.Owin.Security.OAuth;
    
    namespace WebApi.AccessToken
    {
        public class TokenGenerator
        {
            public string ClientId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public IList<string> Scope { get; set; }
    
            private OAuthAuthorizationServerOptions Options { get; } =
                new OAuthAuthorizationServerOptions()
                {
                    //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new CustomOAuthProvider(),
                    AccessTokenFormat = new CustomJwtFormat("http://localhost:59822")
                };
    
            public async Task<IList<KeyValuePair<string, string>>>  InvokeTokenEndpointAsync(IOwinContext owinContext)
            {
                var result = new List<KeyValuePair<string, string>>();
                
                DateTimeOffset currentUtc = Options.SystemClock.UtcNow;
                // remove milliseconds in case they don't round-trip
                currentUtc = currentUtc.Subtract(TimeSpan.FromMilliseconds(currentUtc.Millisecond));
                
                AuthenticationTicket ticket = await InvokeTokenEndpointResourceOwnerPasswordCredentialsGrantAsync(owinContext, Options, currentUtc);
    
                if (ticket == null)
                {
                    result.Add(new KeyValuePair<string, string>("ERROR", "Failed to create acess_token"));
                    return result;
                }
    
                ticket.Properties.IssuedUtc = currentUtc;
                ticket.Properties.ExpiresUtc = currentUtc.Add(Options.AccessTokenExpireTimeSpan);
                ticket = new AuthenticationTicket(ticket.Identity, ticket.Properties);
    
                var accessTokenContext = new AuthenticationTokenCreateContext(
                    owinContext,
                    Options.AccessTokenFormat,
                    ticket);
    
                await Options.AccessTokenProvider.CreateAsync(accessTokenContext);
                string accessToken = accessTokenContext.Token;
    
                if (string.IsNullOrEmpty(accessToken))
                {
                    accessToken = accessTokenContext.SerializeTicket();
                }
    
                DateTimeOffset? accessTokenExpiresUtc = ticket.Properties.ExpiresUtc;
    
                result.Add(new KeyValuePair<string, string>("access_token", accessToken));
                result.Add(new KeyValuePair<string, string>("token_type", "bearer"));
                TimeSpan? expiresTimeSpan = accessTokenExpiresUtc - currentUtc;
                var expiresIn = (long)expiresTimeSpan.Value.TotalSeconds;
                if (expiresIn > 0)
                {
                    result.Add(new KeyValuePair<string, string>("expires_in", "bearer"));
                }
                return result;
            }
    
            private async Task<AuthenticationTicket> InvokeTokenEndpointResourceOwnerPasswordCredentialsGrantAsync(IOwinContext owinContext, OAuthAuthorizationServerOptions options, DateTimeOffset currentUtc)
            {
                var grantContext = new OAuthGrantResourceOwnerCredentialsContext(
                    owinContext, 
                    options, 
                    ClientId, 
                    UserName, 
                    Password, 
                    Scope);
                await options.Provider.GrantResourceOwnerCredentials(grantContext);
                return grantContext.Ticket;
            }
        }
    }
