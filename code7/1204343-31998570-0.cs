    public class AccountController : Controller
    {
        private readonly IMembershipProvider membershipProvider;
        public AccountController(IMembershipProvider membershipProvider)
        {
            this.membershipProvider= membershipProvider;
        }
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();  
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = membershipProvider.Find(viewModel.Username, viewModel.Password);
            if (user != null)
            {
                membershipProvider.SignIn(user, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "Your credentials were not recognised. Please try again.");
            return View(viewModel);
        }
    }
