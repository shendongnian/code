    public ActionResult Login(LoginVM model, string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        if (ModelState.IsValid)
        {
            HttpContext.Current.Session["TokenData"] = RestUtils.GetTokenData(AppDefaults.UrlAPI, AppDefaults.ProxyConfig, model.User, model.Pass);
            Response.SetAuthCookie(model.User, true, model);
            return Redirect(returnUrl);
        }
        return View(model);
    }
    public ActionResult LogOff()
    {
        if (HttpContext.Session != null)
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Abandon();
            HttpContext.Session.RemoveAll();
        }
        FormsAuthentication.SignOut();
        return RedirectToAction("Index", "Home");
    }
