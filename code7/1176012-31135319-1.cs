    public class ValidateControllerAttribute : FilterAttribute, IAuthorizationFilter
    {
    	public void OnAuthorization(AuthorizationContext filterContext)
    	{
    		if (!User.AllowedCategories.Any(x => x == filterContext.RequestContext.RouteData.Values["id"]))
    		{
    			//Redirect user to unauthorized page.
    			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "<<CONTROLLER_NAME>>" }, { "Action", "<<ACTION_NAME>>" } });
    
    			//OR, You can redirect to 403 response
    			//throw new HttpException((int)System.Net.HttpStatusCode.Forbidden, "You do not have permission to view this page");
    		}
    	}
    }
