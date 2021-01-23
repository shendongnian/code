    public override void OnException(HttpActionExecutedContext context)
    {
        context.ExceptionHandled = true;
        context.HttpContext.Response.Clear();
        context.Result = //build the result with needed information
    }
