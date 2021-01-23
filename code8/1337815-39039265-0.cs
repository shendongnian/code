    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _sessionService = context.HttpContext.RequestServices.GetService<ISessionService>();
        if (_sessionService.LoggedInUser == null)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new JsonResult("Unauthorized");
        }
    }
