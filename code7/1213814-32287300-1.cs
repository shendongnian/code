        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (User.GetUserInfo() != null)
            {
                return Redirect(Url.Home());
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect(Url.Home());
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
