    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MyCustomAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Do some logic here to pull authorised roles from backing store (AppSettings, MSSQL, MySQL, MongoDB etc)
    		...
    		// Check that the user belongs to one or more of these roles 
    		bool isUserAuthorized = ....;
    		
    		if(isUserAuthorized) 
    			return true;
    		
            return base.AuthorizeCore(httpContext);
        }
    }
