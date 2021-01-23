     public class Controller
     {
          public User { get { return HttpContext.Current.User; } }
     }
     public class YourController : Controller
     {
          public ActionResult Index()
          {
               return this.User.Identity.Name;
          }
     }
