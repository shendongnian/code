    public class NullableValidatorAttribute : ActionFilterAttribute
    {
    	protected String[] ParametersNames { get; set; }
    	public String HttpNotFoundStatusDescription { get; set; }
    	public NullableValidatorAttribute(params String[] parametersNames)
    	{
    		if (parametersNames == null)
    			throw new ArgumentNullException("parametersNames");
    
    		ParametersNames = parametersNames;
    	}
    
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		var parametersNames = new HashSet<String>(ParametersNames);
    
    		foreach (var parameterName in parametersNames)
    		{
    			var parameterValue = filterContext.ActionParameters[parameterName];
    
    			if (parameterValue == null)
    			{
    				filterContext.Result = new HttpNotFoundResult(HttpNotFoundStatusDescription);
    				return;
    			}
    		}
                
    		base.OnActionExecuting(filterContext);
    	}
    }
