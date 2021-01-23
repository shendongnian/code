public async void Authenticate(string aadInstance, string tenant, string clientId, Uri redirectUri, string resourceId)
        {
            try
            {
                string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
                authContext = new AuthenticationContext(authority, new FileCache());
                AuthenticationResult result = null;
                try
                {
                    result = await authContext.AcquireTokenSilentAsync (resourceId, clientId);
                }
                catch (AdalException ex)
                {
                    if (ex.ErrorCode == AdalError.UserInteractionRequired || ex.ErrorCode == AdalError.FailedToAcquireTokenSilently)
                    {
                        result = await authContext.AcquireTokenAsync(resourceId, clientId, redirectUri, new PlatformParameters(PromptBehavior.Always));
                    }
                }
                ticket = result.AccessToken;
                user = result.UserInfo.DisplayableId.Split('@')[0];
            }
            catch (Exception ex)
            {
                ticket = "Error";
                throw ex;
            }
        }
**Server side code**
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
private JwtSecurityToken Validate(string token)
        {
            string stsDiscoveryEndpoint = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";
            ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever());
            OpenIdConnectConfiguration config = configManager.GetConfigurationAsync().Result;
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKeys = config.SigningKeys, //.net core calls it "IssuerSigningKeys" and "SigningKeys"
                ValidateLifetime = true
            };
            JwtSecurityTokenHandler tokendHandler = new JwtSecurityTokenHandler();
            SecurityToken jwt;
            var result = tokendHandler.ValidateToken(token, validationParameters, out jwt);
            return jwt as JwtSecurityToken;
        }
