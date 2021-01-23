    [HttpPost]
    public ActionResult Register(RegisterModel model, string returnUrl)
    {
        // do the register thing
        if (!String.IsNullOrWhiteSpace(returnUrl))
        {
            return Redirect(returnUrl);
        }
        return RedirectToAction("Index"); // or whatever should be default
    }
