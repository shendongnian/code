    // The interface for the service.
    public interface IAccountService
    {
        User CurrentUser { get; }
        string CurrentUserId { get; }
    }
    // The class which implements the interface
    public class AccountService : IAccountService
    {
        private IHttpContextAccessor _httpContextAccessor;
		
		// This is a custom services which has access to the business model and the data model
        private IUserService _userService;
        private string _currentUserId;
        private User _currentUser;
        public AccountService(IHttpContextAccessor httpContextAccessor, IUserService currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _coreServiceProvider = coreServiceProvider;
            _currentUserId = null;
            _currentUser = null;
        }
        public User CurrentUser
        {
            get
            {
                if (_currentUser != null)
                {
                    return _currentUser;
                }
                if (string.IsNullOrEmpty(_currentUserId))
                {
				    // Get the user ID of the currently logged in user.	
                    // using System.Security.Claims;					
                    _currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
                }
                if (!string.IsNullOrEmpty(_currentUserId))
                {
                    _currentUser = _userService.Find(_currentUserId);
                    if (_currentUser == null)
                    {
                        string errMsg = string.Format("User with id {0} is authenticated but no user record is found.", _currentUserId);
                        throw new Exception(errMsg);
                    }
                }
                return _currentUser;
            }
        }
        public string CurrentUserId
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentUserId))
                {
                    return _currentUserId;
                }
				
                // Get the user ID of the currently logged in user.	
				// using System.Security.Claims;
                _currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
                return _currentUserId;
            }
        }
    }
