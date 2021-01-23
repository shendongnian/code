    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator")) 
               return RedirectToAction("PagetoRedirect");
            else
               return RedirectToAction("CommonPagetoShowApplicationAsClosed");
        }
    }
