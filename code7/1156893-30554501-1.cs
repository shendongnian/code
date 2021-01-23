    public static string GetSomething(this IIdentity identity)
    {
    	if (identity.IsAuthenticated)
    	{
    		var userStore = new UserStore<ApplicationUser>(new Context());
    		var manager = new UserManager<ApplicationUser>(userStore);
    		var currentUser = manager.FindById(identity.GetUserId());
    		return something = currentUser.something;                
    	}
    	return null;
    }
