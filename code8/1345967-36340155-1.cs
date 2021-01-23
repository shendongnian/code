    public class AuthRepository : IAuthRepository, IDisposable
    {
        public AuthRepository(UserManager<UserInfo> userManager)
        {
            _userManager = userManager;
        }
        ...
    }
    public class UserManager<T>
    {
        private UserAuthContext _userAuthContext;
        public UserManager<T>(UserAuthContext userAuthContext)
        {
            _userAuthContext = userAuthContext;
        }
        ...
    }
