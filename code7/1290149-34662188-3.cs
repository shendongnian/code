    public class AuthorizedFilter : ActionFilterAttribute
    {   
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        	//Do your logic here
        	var cookieValue = filterContext.HttpContext.Request.Cookies["userCookie"]).FirstOrDefault();
    
        	if(cookieValue != null)
        		return;
    	    	
            filterContext.Result = new RedirectToRouteResult(
    	                    new RouteValueDictionary
    	                    {
    	                        {"controller", "Home"},
    	                        {"action", "Login"},
    	                    });
        }
    }
