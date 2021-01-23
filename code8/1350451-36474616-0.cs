    public class LogInjectorFilterAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(HttpActionContext actionContext)
    	{
    		const string key = "loglevel";
    		if (actionContext.ActionArguments.ContainsKey(key))
    		{
    			var loglevel = (int) actionContext.ActionArguments[key];
    			LogCollector logger = new LogCollector(loglevel);
    			actionContext.ActionArguments["logger"] = logger;
    		}
    		base.OnActionExecuting(actionContext);
    	}
    }
