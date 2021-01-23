    //using Microsoft.AspNet.Identity.Owin;
    //using Microsoft.Owin.Security;
    //using Microsoft.Owin.Security.OAuth;
    //using System;
    //using System.Collections.Generic;
    //using System.Security.Claims;
    //using System.Threading.Tasks;
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
                throw new ArgumentNullException("publicClientId");
            _publicClientId = publicClientId;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager);
            var propertyDictionary = new Dictionary<string, string> { { "userName", user.UserName } };
            var properties = new AuthenticationProperties(propertyDictionary);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            // Token is validated.
            context.Validated(ticket);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
                context.Validated();
            return Task.FromResult<object>(null);
        }
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                var expectedRootUri = new Uri(context.Request.Uri, "/");
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
