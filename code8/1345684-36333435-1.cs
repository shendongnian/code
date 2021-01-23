    public ActionResult Foo (MyModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            // do something
            if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Fallback");
        }
        return View(model);
    }
