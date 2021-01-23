    public ActionResult Index()
    {
      MyViewModel model = new MyViewModel();
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Save and redirect
    }
    private void ConfigureViewModel(MyViewModel model)
    {
      model.Items = Enumerable.Range(1, 5).Select(x => new SelectListItem
      {
        Value = x.ToString(),
        Text = "item " + x
      });
    }
