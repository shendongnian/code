    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
        if (controllerActionDescriptor != null)
        {
            var actionAttributes = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(inherit: true);
        }
    }
