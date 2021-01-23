    public class ReferrerController : Controller {
        public ActionResult Index(string referrer) {
            
            if (Session["Referrer"] != null) {
                // do nothing, already used as entry point in the current session
            } else {
                // handle referrer, probably also some timestamp or hash
                Session["Referrer"] = referrer; // save in session
            }
            return RedirectToRoute("~/"); // redirect to home
        }
    }
