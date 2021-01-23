    public ActionResult Index()
    {
        var viewModel = LoadViewModel(null);
        LoadSelections();
    
        return View(viewModel);
    }
