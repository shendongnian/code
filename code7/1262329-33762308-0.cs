    public class MyCustomAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        var myID = filterContext
          .RouteData["id"] as int?
        var user = filterContext.Controller.User;
      }
    }
