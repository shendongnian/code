    public ActionResult LogOut()
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon(); 
        return RedirectToAction("index", "main");
    }
