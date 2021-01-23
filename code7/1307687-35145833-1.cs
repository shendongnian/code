    public ActionResult Index(int FormId)
    {
        var getViews = db.fetchViews.where id = 1; //get views from db
        var viewpath = string.Format("~/Views/Form/{0}/{0}", getviews.viewName);
        return View(viewpath);
    }
