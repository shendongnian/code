    public class ValidateModelAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(HttpActionContext actionContext)
    	{
    		if (actionContext.ModelState.IsValid)
    		{
    			return;
    		}
    
    		//Do error handling Stuff...
    	}
    }
