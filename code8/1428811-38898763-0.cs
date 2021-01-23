    public void OnActionExecuting(ActionExecutingContext actionContext)
    {
        foreach(var argument in actionContext.ActionArguments.Values.Where(v => v is T)))
        {
             T model = argument as T;
             // your logic
        }
    }
