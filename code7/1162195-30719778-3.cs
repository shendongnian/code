    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult HandlePost
    {
        string selectProcess = Request.Form("selectProcess");
        // process selectProcess data however you need
        return RedirectToAction("Index", "Home");
    }
