    public class DisposeDbContextFilterAttribute : ActionFilterAttribute
    {
        private static readonly DbContextHelper contextHelper = new DbContextHelper();
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            contextHelper.DisposeContext();
        }
    }
 
