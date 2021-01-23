    protected override void OnException(ExceptionContext filterContext)
    {
        filterContext.Result = Json(new {Message = filterContext.Exception.Message});
        filterContext.ExceptionHandled = true;
    }
