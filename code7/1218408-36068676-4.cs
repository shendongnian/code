    public class logInController : Controller {
        private IAuthenticationService authenticator;
        private IFormsAuthenticationService formsAuthentication;
    
        public MvcTestsController(IAuthenticationService userAuthentication, IFormsAuthenticationService formsAuthentication) {
            this.authenticator = userAuthentication;
            this.formsAuthentication = formsAuthentication;
        }
    
        [HttpPost]
        public ActionResult Index(logInModel model) {
            if (ModelState.IsValid) {
                bool match = authenticator.Authenticate(model.Username, model.Password);
                if (match) {
                    formsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("index", "home");
                } else
                    ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }
    }
