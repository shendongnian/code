    public class ValidateUserFilter : IActionFilter
    {
    	public void OnActionExecuted(ActionExecutedContext filterContext)
    	{
    		
    	}
    
    	public void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		//Controllers to avoid validation
    		if ((new[] { "<<CONTROLLER1>>", "<<CONTROLLER2>>" }).Any(x => x == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
    		{
    			return;
    		}
    
    		if (!User.AllowedCategories.Any(x => x == FilterContext.RequestContext.RouteData.Values["id"]))
    		{
    			//Redirect user to unauthorized page.
    			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "<<CONTROLLER_NAME>>" }, { "Action", "<<ACTION_NAME>>" } });
    		}
    	}
    }
