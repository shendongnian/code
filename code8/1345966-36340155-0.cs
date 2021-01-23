    public class SimpleAuthorizationServerProvider 
    {
        private IAuthRepository _authRepository;
        public SimpleAuthorizationServerProvider(IAuthRepository authRepository)
        {
            _authRepository = authRepository
        }
        
        ...
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
