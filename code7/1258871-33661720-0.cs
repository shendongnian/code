    public ActionResult Edit()
    {
        // Do some edit stuff
        ViewBag.FormType = "Create";
        return View();
    }
    public ActionResult Create()
    {
        // Do some create stuff
        ViewBag.FormType = "Create";
        return View();
    }
