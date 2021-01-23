    public class PagesController : Controller
    {
        public ActionResult Index(string id)
        {
            if (matchesOtherRoute(id))
                RedirectToAction("OtherAction", "OtherController");
            if (!userExists(id))
                RedirectToAction("NotFoundAction", "ErrorController");
            // Do other stuff here
         }
    }
            
