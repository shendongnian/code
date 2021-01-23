    public ActionResult Index()
    {
        dynamic model = new ExpandoObject();
        model.ShowFlag = "True";
        ViewBag.ShowFlag = "ViewBag True";
        return View(model);
    }
