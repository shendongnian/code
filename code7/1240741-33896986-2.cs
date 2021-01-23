    // POST: /ClientAccount/Login
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
            if (ModelState.IsValid)
            {
                //try to pick the password from database
            ClientAccountDAO userManager = ClientAccountDAO.Instance;
                string password = userManager.GetUserPassword(model.Password);
                if (string.IsNullOrEmpty(password))
                {
                 //the password wars not found in database
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                    
                }
                if (model.Password == password)
                {
                    //password is in database, do login FormsAuthentication.SetAuthCookie(model.Username, false);
                    System.Web.HttpContext.Current.Session["name"] = model.Username;
                    System.Web.HttpContext.Current.Session["nameSurname"] = clientDao.getName(model.Username, model.Password);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Docs", "ClientAccount");
                    }
                }
                else
                {
                    
                    ModelState.AddModelError("", "Username or password not correct");
                }
            }
            ViewBag.Successfull = false;
            // If we got this far, something failed, redisplay form
            return View("Login", model);
        }
