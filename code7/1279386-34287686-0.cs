        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginModel { strReturnUrl = ReturnUrl };
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel viewmodel, bool remember = false)
        {
            if (ModelState.IsValid)
            {
                var user = _user.GetAll(a => a.Username == viewmodel.UserName && a.Password == viewmodel.Password && a.IsActive == true && a.IsDeleted != true).FirstOrDefault();
                if (user != null)
                {
                    await SignInAsync(user, remember);
                    return RedirectToLocal(viewmodel.strReturnUrl, user);
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The email or password provided is incorrect.");
            return View(viewmodel);
        }
        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AccountHelper.SignIn(user, isPersistent);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl, Dental_testData.User user)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (user.RoleId == (int)common.Role.Customer)
                {
                    return RedirectToAction("Index", "Home", new { @area = "Customer" });
                }
                return RedirectToAction("Index", "Home");
            }
        }
