    public class AuthClient 
    {
        string Dictionary<string, IList<UserPermissions> _userPermissions;
    	private IAuthenticationService _authenticationService;
    	private IAuthorizationService _authorizationService;
    	
    	public AuthClient(IAuthenticationService authenticationService, IAuthorizationService authorizationService)
    	{
    		_authenticationService = authenticationService;
    		_authorizationService = authorizationService;
    	}
    
        User Login(string username, string password)
        {
            User user = _authenticationService.Login(username, password);
    
            var permissions = _authorizationService.GetPermissions(user);
            _userPermissions.Add(user.Username, permissions);
    
            return user;
        }
    }
