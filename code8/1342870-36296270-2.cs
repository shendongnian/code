    public interface IAuthManager
    {
    	Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool rememberMe);
    }
    
    public class AuthManager : IAuthManager
    {
    	private ApplicationUserManager _userManager;
    	ApplicationSignInManager _signInManager;
    
    	public AuthManager(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    	{
    		this._userManager = userManager;
    		this._signInManager = signInManager;
    	}
    
    	public async Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool rememberMe)
    	{
    		return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, true).ConfigureAwait(false);
    	}
    }
