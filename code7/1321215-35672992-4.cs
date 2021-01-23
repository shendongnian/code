    public sealed class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.ActionContext.ActionArguments["message"] = "your redirect URL";
        }
    }
