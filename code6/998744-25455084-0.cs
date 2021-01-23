    [Authorize][HttpGet]
    public ActionResult Create()
    {
        return View(GetCreateSalonViewModel());
    }
    [HttpPost]
    public ActionResult Create(CreateSalonViewModel model) 
    {  // MVC will try to bind your POSTed form to parameters
    ...
    }
