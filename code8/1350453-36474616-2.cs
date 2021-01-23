    public class LogInjectorFilterAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(HttpActionContext actionContext)
    	{
    		const string key = "loglevel";
    		if(actionContext.ControllerContext.RouteData.Values.ContainsKey(key))
    		{
    			var loglevel = int.Parse(actionContext.ControllerContext.RouteData.Values[key].ToString());
    			LogCollector logger = new LogCollector(loglevel);
    			actionContext.ActionArguments["logger"] = logger;
    		}
    		base.OnActionExecuting(actionContext);
    	}
    }
