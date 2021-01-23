    public ActionResult LogOut()
    {
        FormsAuthentication.SignOut();
        Session.Abandon(); // it will clear the session at the end of request
        return RedirectToAction("index", "main");
    }
