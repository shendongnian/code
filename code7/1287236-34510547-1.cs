    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.CustomObject1 = customObject1;
        model.CustomObject2 = customObject2;
        return View(model);
    }
