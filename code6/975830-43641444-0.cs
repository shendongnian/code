    private static bool ShouldSkipAuthorization(HttpActionContext actionContext)
    {
        return 
            actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any() ||
            actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any();
    }
