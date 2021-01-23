        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl, ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("RedirectLogin"); 
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        public ActionResult RedirectLogin(string returnUrl)
        {
            if(User.IsInRole("Admin")){
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (User.IsInRole("Optician"))
                    {
                        return RedirectToAction("Index","Optician");
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
        }
