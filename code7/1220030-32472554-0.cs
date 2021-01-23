        public class ReplaceTagsAttribute : ActionFilterAttribute
     {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           var response = filterContext.HttpContext.Response;
     if (response.Filter == null) return; // <-----
    response.Filter = new BundleAndMinifyResponseFilter(response.Filter);
                      
        }
     }
