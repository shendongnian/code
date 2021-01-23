     [AuthoriseUser]
     public class YourController : Controller
     {
       public ActionResult YourAction()
       {
       }
     }
    public class AuthoriseUserAttribute : ActionFilterAttribute
    {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       // Check user is authenticated 
       // if user is not authenticated then do as :
         filterContext.Result = new RedirectToRouteResult(new
         RouteValueDictionary(new { controller = "Login", action = "Index" }));
    }
    }
