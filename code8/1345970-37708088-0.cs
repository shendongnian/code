    public class SimpleAuthorizationServerProvider 
    {
        private IAuthRepository _authRepository;
    
        public SimpleAuthorizationServerProvider(IAuthRepository authRepository)
        {
            _authRepository = authRepository
        }
    
        ...
