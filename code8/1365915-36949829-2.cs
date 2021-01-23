    public ActionResult Create()
    {
        VaraVM model = new VaraVM();
        ConfigureViewModel(model);
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(VaraVM model)
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model);
            return View(model);  
        }
        // map the view model to a new instance of the data model
        // save and redirect
    }
    private void ConfigureViewModel(VaraVM model)
    {
        model.CategoryList = .... // your query
    }
    
    
