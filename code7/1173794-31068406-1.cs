    [HttpGet]
    [Authorize]
    public ActionResult ImportVerify()
    {
        List<ExampleModel> model = //populate the list somehow
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    public ActionResult ImportVerify(List<ExampleModel> model)
    {
        //do something
    }
