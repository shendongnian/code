    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        ActionParameters = actionContext.ActionArguments;
		if (actionContext.ActionArguments.ContainsKey("Key1"))
		{
		  var val = actionContext.ActionArguments["Key1"] as string;
		}        
    }
