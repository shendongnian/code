    public class TestMethodIfLoggedIn : ActionFilterAttribute
       {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
           {
             base.OnActionExecuting(filterContext);
             var a = HttpContext.Current.Session["a"];
             var b = HttpContext.Current.Session["b"];
                
           if(a.ToString() == b.ToString())
            { 
               HttpContext.Current.Session["Message"] = "A = B";
            }
         else    
             {
                HttpContext.Current.Session["Message"] = "A is not equal to b";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Desired_Controller_Name",
                    action = "ActionName"
                }));
            }
        }
    }
