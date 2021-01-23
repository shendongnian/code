        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (EFNameEntities db = new EFNameEntities ())
            {
                var UserData = from ANU in db.AspNetUsers
                               where ANU.UserName == model.UserName
                               select new
                               {
                                   ANU.isAuthorized,
                                   ANU.isActive
                               };
                foreach (var c in UserData)
                {
                    //If User is NOT Authorized to log in
                    if (!Convert.ToBoolean(c.isAuthorized))
                    {
                        ModelState.AddModelError("", "This User is not Authorized to Login.");
                        return View(model);
                    }
                    else
                    {
                        //If User is NOT Active
                        if (!Convert.ToBoolean(c.isActive))
                        {
                            ModelState.AddModelError("", "This User is not Active.");
                            return View(model);
                        }
                    }
                }
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                //case SignInStatus.UnAuthorized:
                //    return View("UnAuthorized");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                     //Incorrect password or user does not exist
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
