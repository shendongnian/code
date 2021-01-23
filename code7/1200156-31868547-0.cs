    public class HomeController : Controller
    {
      public PartialViewResult SomeAction()
      {
        // When debugging, I can break here and
        // see the Session in the Immediate Window
        var b = SessionHelper.SomeProperty;
      }
    }
    
    public class SessionHelper
    {
      public static object SomeProperty
      {
        get
        {
          return System.Web.HttpContext.Current.Session["MyProperty"];
        }
      }
    }
