        [Authorize]
        public class AccountController : Controller
        {
            //
            // GET: /Account/Login
            [AllowAnonymous]
            public ActionResult Login(string returnUrl)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
            //
            // POST: /Account/Login
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public ActionResult Login(LoginViewModel model, string ReturnUrl)
            {
                if (ModelState.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return View(model);
            }
            //
            // GET: /Account/LogOff
            public ActionResult LogOff()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }
