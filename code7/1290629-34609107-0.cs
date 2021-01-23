    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.Text = ... go fetch from your db
        return View(model);
    }
