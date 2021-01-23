      [CheckUserRole]
      public class YourController : Controller
      {
        public ActionResult YourAction()
        {
        
        }
      }
     public class CheckUserRoleAttribute : ActionFilterAttribute
     {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // Get the User Id from the session
           // Get Role associated with the user (probably from database)
           // Get the permission associated with the role (like Read, write etc)
  
           // if user is not authenticated then do as :
             filterContext.Result = new RedirectToRouteResult(new
             RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
        }
     }
