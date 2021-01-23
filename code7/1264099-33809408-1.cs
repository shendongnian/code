    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        var parameterDescriptor = actionContext.ActionDescriptor.GetParameters().FirstOrDefault(x => typeof(CollectionFilterMapping).IsAssignableFrom(x.ParameterType));
        if (parameterDescriptor != null && actionContext.ActionArguments[parameterDescriptor.ParameterName] == null)
        {
            actionContext.ActionArguments[parameterDescriptor.ParameterName] = Activator.CreateInstance(parameterDescriptor.ParameterType);
        }
        base.OnActionExecuting(actionContext);
    }
