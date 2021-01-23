    public ActionResult LogOff()
    {
        AuthenticationManager.SignOut();
        return RedirectToAction("Index", "Home");
    }
