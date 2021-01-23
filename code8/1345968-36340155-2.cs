    public class SimpleAuthorizationServerProvider 
    {
        private IAuthRepository _authRepository;
        public SimpleAuthorizationServerProvider(IAuthRepository authRepository)
        {
            _authRepository = authRepository
        }
        ...
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            // no need for new repository anymore
            // class already has repository injected 
            IdentityUser user = await _authRepository.FindUser(context.UserName, context.Password);
        
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
        
            context.Validated(identity);
        }
    }
    public class AuthRepository : IAuthRepository, IDisposable
    {
        public AuthRepository(UserAuthContext userAuthContext, UserManager<UserInfo> userManager)
        {
            _userAuthContext = userAuthContext;
            _userManager = userManager;
        }
        ...
    }
