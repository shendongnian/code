    public class UserFactory
    {
    	private readonly IHttpContextAccessor _httpContextAccessor;
    
    	public UserFactory(IHttpContextAccessor httpContextAccessor) 
    	{
    		_httpContextAccessor = httpContextAccessor;
    	}
    
    	// other code...
    }
