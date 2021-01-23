    [CustomAuthorize(Roles="Admin,Manager")]
    public class MyController
    {
    
          // Everyone has access
          [AllowAnonymous]
          public ActionResult Index()
          {
          return View();
          }
    
          // Only Admin and Manager roles have access, everyone else is denied
          public ActionResult About()
          {
          return View();
          } 
    
    }
