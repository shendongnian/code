    public class Foo()
    {
       private readonly IActionContextAccessor _actionContextAccessor;
    
        public Foo(IActionContextAccessor actionContextAccessor){
             _actionContextAccessor = actionContextAccessor;
        }
    
         private LogInformation GetLogInfo(IHttpContextAccessor requestContext)
        {
            .
            .
            .
            Log.Refrence = _actionContextAccessor.ActionContext.RouteData.Values["controller"] + "/" +    _actionContextAccessor.ActionContext.RouteData.Values["action"];
            .
            .
            .
            return Log;
        } 
    }
