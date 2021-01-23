    public override Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = _statusCode;
        return base.ExecuteResultAsync(context);
    }
