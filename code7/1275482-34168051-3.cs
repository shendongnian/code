    public  class CustomHandleErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.Clear();
            context.Result = //build the result with needed information
        }
    }
    [CustomHandleError]
    public lass <Controller>.......
