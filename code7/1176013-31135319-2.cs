    public class ValidateActionAttribute : ActionMethodSelectorAttribute
    {
    	public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
    	{
    		if (!User.AllowedCategories.Any(x => x == controllerContext.RequestContext.RouteData.Values["id"]))
    		{
    			//Redirect user to unauthorized page.
    			controllerContext.HttpContext.Response.Clear();
    			controllerContext.HttpContext.Response.Redirect("~/<<CONTROLLER_NAME>>/<<ACTION_NAME>>");
    			return false;
    
    			//OR, You can redirect to 403 response
    			//throw new HttpException((int)System.Net.HttpStatusCode.Forbidden, "You do not have permission to view this page");
    
    			/*OR,
    			controllerContext.HttpContext.Response.StatusCode = 403;
    			return true;*/
    		}
    	}
    }
