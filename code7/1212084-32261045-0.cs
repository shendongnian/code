    public sealed class ApplicationUser
    {
    	// SINGLETON-LIKE REFERENCE TO CURRENT USER ONLY
    	
    	public static ApplicationUser CurrentUser
        { 
            get 
            { 
                return GetUser(HttpContext.Current.User.Identity.Name); 
            } 
        }
    
    	// MULTITON IMPLEMENTATION (based on http://stackoverflow.com/a/32238734/979621)
    	
    	private static Dictionary<string, ApplicationUser> applicationUsers 
    							= new Dictionary<string, ApplicationUser>();
    
    	private static ApplicationUser GetUser(string username)
    	{
    		ApplicationUser user = null;
    
    		//lock collection to prevent changes during operation
    		lock (applicationUsers)
    		{
    			// find existing value, or create a new one and add
    			if (!applicationUsers.TryGetValue(username, out user)) 
    			{
    				user = new ApplicationUser();
    				applicationUsers.Add(username, user);
    			}
    		}
    
    		return user;
    	}
    
    	private ApplicationUser()
    	{
    		GetUserDetails(); // determine current user's AD groups and access level
    	}
    
    	// REST OF THE CLASS CODE
    	
    	public string Name { get { return name; } }
    	public bool IsAuthorized { get { return isAuthorized; } }
    	public bool IsAdmin { get { return isAdmin; } }
    
    	private string name = HttpContext.Current.User.Identity.Name;
    	private bool isAuthorized = false;
    	private bool isAdmin = false;
    
    	// Get User details
    	private void GetUserDetails()
    	{
    		// Check user's AD groups and determine isAuthorized and isAdmin
    	}
    }
