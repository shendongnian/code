    //GET Action
    public ActionResult Create(string Category)
    {
        object viewmodel = null;
    
        switch (Category)
        {
            case "Motherboards":
                viewModel = new MotherboardsViewModel { };
                break;
            case "Cases":
                viewModel = new CasesViewModel { };
                break;
            default:
                viewModel = new DrivesViewModel { };
                break;
        }
    
        //Here i use switched viewmodel to change some values, like:
        viewModel.Name = GetRandomName();
        ...
    
        //And i return view and viewmodel
        return View(Category + "View", viewmodel)
    }
