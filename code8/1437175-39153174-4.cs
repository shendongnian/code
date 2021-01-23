    public class AccountController : Controller {
        IUserManager userManagerModel;
        IAuthenticationService formsAuthentication;
        public AccountController(IUserManager userManagerModel, IAuthenticationService formsAuthentication) {
            this.userManagerModel = userManagerModel;
            this.formsAuthentication = formsAuthentication;
        }
        public ActionResult SignUp() {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserSignUpView userSignUpView) {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            } else if (!ModelState.IsValid) {
                return View(userSignUpView);
            }
            string error = userManagerModel.CheckIfAccountExists(userSignUpView.LoginName, userSignUpView.Email);
            if (error != null) {
                ModelState.AddModelError("", error);
                return View(userSignUpView);
            } else {
                userManagerModel.AddAccount(userSignUpView);
                formsAuthentication.SetAuthCookie(userSignUpView.LoginName, false);
                return RedirectToAction("Welcome", "Home");
            }
        }
    }
