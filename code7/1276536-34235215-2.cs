    public ActionResult Index()
    {
      var model = new yourConcreteModel();
      ConfigureBaseViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Index(yourConcreteModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureBaseViewModel(model);
        return View(model);
      }
      // save and redirect
    }
