    public override void OnAuthorization(HttpActionContext filterContext)
	{
		var requestScope = filterContext.Request.GetDependencyScope();
		_userService = requestScope.GetService(typeof(IUserService)) as IUserService;
	}
	
	//
	// Summary:
	//     Retrieves the System.Web.Http.Dependencies.IDependencyScope for the given request
	//     or null if not available.
	//
	// Parameters:
	//   request:
	//     The HTTP request.
	//
	// Returns:
	//     The System.Web.Http.Dependencies.IDependencyScope for the given request or null
	//     if not available.
	public static IDependencyScope GetDependencyScope(this HttpRequestMessage request);
