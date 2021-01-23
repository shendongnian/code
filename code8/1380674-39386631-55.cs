    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNet.Security.OpenIdConnect.Extensions;
    using AspNet.Security.OpenIdConnect.Server;
    using Newtonsoft.Json;
    using BlogCore.Services;
    using Shared.Enums;
    using System.Linq;
    using Shared.GlobalVariables;
    
    namespace Shared.Providers
    {
    public class AuthenticationProvider : OpenIdConnectServerProvider
    {
    
        private readonly IApplicationService _applicationservice;
        private readonly IUserService _userService;
        public AuthenticationProvider(IUserService userService, 
                                      IApplicationService applicationservice)
        {
            _applicationservice = applicationservice;
            _userService = userService;
        }
    
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            if (string.IsNullOrEmpty(context.ClientId))
            {
                context.Reject(
                    error: OpenIdConnectConstants.Errors.InvalidRequest,
                    description: "Missing credentials: ensure that your credentials were correctly " +
                                 "flowed in the request body or in the authorization header");
    
                return Task.FromResult(0);
            }
    
            #region Validate Client
            var application = _applicationservice.GetByClientId(context.ClientId);
    
                if (applicationResult == null)
                {
                    context.Reject(
                                error: OpenIdConnectConstants.Errors.InvalidClient,
                                description: "Application not found in the database: ensure that your client_id is correct");
    
                    return Task.FromResult(0);
                }
                else
                {
                    var application = applicationResult.Data;
                    if (application.ApplicationType == (int)ApplicationTypes.JavaScript)
                    {
                        // Note: the context is marked as skipped instead of validated because the client
                        // is not trusted (JavaScript applications cannot keep their credentials secret).
                        context.Skip();
                    }
                    else
                    {
                        context.Reject(
                                error: OpenIdConnectConstants.Errors.InvalidClient,
                                description: "Authorization server only handles Javascript application.");
    
                        return Task.FromResult(0);
                    }
                }
            #endregion Validate Client
   
            return Task.FromResult(0);
        }
    
        public override async Task HandleTokenRequest(HandleTokenRequestContext context)
        {
            if (context.Request.IsPasswordGrantType())
            {
                var username = context.Request.Username.ToLowerInvariant();
                var user = await _userService.GetUserLoginDtoAsync(
                    // filter
                    u => u.UserName == username
                );
                
                if (user == null)
                {
                    context.Reject(
                            error: OpenIdConnectConstants.Errors.InvalidGrant,
                            description: "Invalid username or password.");
                    return;
                }
                var password = context.Request.Password;
    
                var passWordCheckResult = await _userService.CheckUserPasswordAsync(user, context.Request.Password);
    
    
                if (!passWordCheckResult)
                {
                    context.Reject(
                            error: OpenIdConnectConstants.Errors.InvalidGrant,
                            description: "Invalid username or password.");
                    return;
                }
    
                var roles = await _userService.GetUserRolesAsync(user);
    
                if (!roles.Any())
                {
                    context.Reject(
                            error: OpenIdConnectConstants.Errors.InvalidRequest,
                            description: "Invalid user configuration.");
                    return;
                }
            // add the claims
            var identity = new ClaimsIdentity(context.Options.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, user.Id, OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
            identity.AddClaim(ClaimTypes.Name, user.UserName, OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
             // add the user's roles as claims
            foreach (var role in roles)
            {
                identity.AddClaim(ClaimTypes.Role, role, OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
            }
             context.Validate(new ClaimsPrincipal(identity));
            }
            else
            {
                context.Reject(
                        error: OpenIdConnectConstants.Errors.InvalidGrant,
                        description: "Invalid grant type.");
                return;
            }
    
            return;
        }
    
        public override Task ApplyTokenResponse(ApplyTokenResponseContext context)
        {
            var token = context.Response.Root;
            
            var stringified = JsonConvert.SerializeObject(token);
            // the token will be stored in a cookie on the client
            context.HttpContext.Response.Cookies.Append(
                "exampleToken",
                stringified,
                new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true, // to prevent XSS
                    Secure = false, // set to true in production
                    Expires = // your token life time
                }
            );
    
            return base.ApplyTokenResponse(context);
        }
    }
    }
