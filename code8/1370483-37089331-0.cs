    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.SomeProperty = "some property value";
        return View(model);
    }
