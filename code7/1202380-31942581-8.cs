    [HttpGet]
    public ActionResult Index()
    {
        var model = new SampleModel();
        model.StepNumber = 1;
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(SampleModel model)
    {
        if (model == null)
        {
            model = new SampleModel();
            return View(model);
        }
        if (!ModelState.IsValid)
            return View(model);
    
        model.StepNumber++;
        return View(model);
    }
