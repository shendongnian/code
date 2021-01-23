    public ActionResult Action1(Model user)
    {
        if (ModelState.IsValid)
        {
           // all is okay
        }
        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        return View(model);
    }
