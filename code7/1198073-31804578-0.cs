    public class AntiXssFilter: FilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
           var request = filterContext.HttpContext.Request;
           // check your request for any xss violations.
           // e.g. request.InputStream
    
        }
    }
