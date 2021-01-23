    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
    if (Request.IsAuthenticated)
    {
     return RedirectToAction("Index", "Home");
    }
    ViewBag.ReturnUrl = returnUrl;
    return View();
    }
