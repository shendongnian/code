    /// <summary>
    /// Manipulate the URL before the WebAPI request has been processed.
    /// </summary>
    /// <remarks>Simplifies logic and post-processing operations</remarks>
    /// <param name="actionContext"></param>
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        // Perform operations that require modification of the Url in OnActionExecuting instead of ApplyQuery.
        // Apply Query should not modify the original Url if you can help it because there can be other validator
        // processes that already have expectations on the output matching the original input request.
        // This goes for injecting or mofying $select, $expand or $count parameters
        // Modify the actionContext request directly before returning the base operation
        // actionContext.Request.RequestUri = new Uri(modifiedUrl);
        base.OnActionExecuting(actionContext);
    }
