    public class AccountController : Controller
    {
        //... ctor, user service
        private IAuthenticationManager Authentication
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private void SignInOwin(string name, bool rememberMe, IEnumerable<string> roles)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, name) },
                DefaultAuthenticationTypes.ApplicationCookie,
                    ClaimTypes.Name, ClaimTypes.Role);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = rememberMe
            }, identity);
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignInInput input)
        {
            if (!ModelState.IsValid)
            {
                input.Password = null;
                input.Login = null;
                return View(input);
            }
            var user = userService.Get(input.Login, input.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "incorrect username or password");
                return View();
            }
            SignInOwin(user.Login, input.Remember, user.Roles.Select(o => o.Name));
            return RedirectToAction("index", "home");
        }
        public ActionResult SignOff()
        {
            Authentication.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
