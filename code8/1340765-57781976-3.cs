    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]    
    public class HbValidateAntiForgeryToken : FilterAttribute, IAuthorizationFilter, IExceptionFilter    
    {    
        public void OnAuthorization(AuthorizationContext filterContext)
    	{
    		try
    		{
    			var antiForgeryCookie = filterContext.HttpContext.Request.Cookies[AntiForgeryConfig.CookieName];
    			AntiForgery.Validate(antiForgeryCookie != null ? antiForgeryCookie.Value : null,
    				filterContext.HttpContext.Request.Headers["__RequestVerificationToken"]);                
    		}
    		catch (Exception ex)
    		{                
    			throw new SecurityException("Unauthorised access detected and blocked");
    		}
    	}
    	
    	public void OnException(ExceptionContext filterContext)
    	{
    		if (filterContext.Exception != null &&
    			filterContext.Exception is System.Security.SecurityException)
    		{
    			filterContext.Result = new HttpUnauthorizedResult();
    			// Handle error page scenario here
    		}
    	}
    }
