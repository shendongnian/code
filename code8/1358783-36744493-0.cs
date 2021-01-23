        public abstract class BaseController : Controller
        {           
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult LogOff()
            {
                FormsAuthentication.SignOut();
    
                //Redirect to home page when logging off.
                return Redirect("~/");
            } 
        }
