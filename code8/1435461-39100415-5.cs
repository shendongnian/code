    public class LoginFilter : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          if(HttpContext.Current.Session["IsLoggedIn"]==false) //or null
          {
             //redirect to login page
          }
       }
    }
