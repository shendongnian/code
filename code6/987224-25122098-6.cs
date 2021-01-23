    public class YourController : Controller
    {
      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        //....Check user authentication here           
      }
    }
    public class MyController : YourController 
    {
      public ActionResult Myaction()
      {
        // ...
      }
    }
