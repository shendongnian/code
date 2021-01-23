    //GET Action
    public ActionResult Create(string Category)
    {
        object viewmodel = null;
    
        switch (Category)
        {
            case "Motherboards":
                MotherboardviewModel = new MotherboardsViewModel { };
                //Here i use switched viewmodel to change some values, like:
                MotherboardviewModel.Name = GetRandomName();
                ...
                viewModel = MotherboardviewModel;
                break;
            case "Cases":
                CaseviewModel = new CasesViewModel { };
                //Here i use switched viewmodel to change some values, like:
                CaseviewModel.Name = GetRandomName();
                ...
                viewModel = CasesviewModel;
                break;
            default:
                DriveviewModel = new DrivesViewModel { };
                //Here i use switched viewmodel to change some values, like:
                DriveviewModel.Name = GetRandomName();
                ...
                viewModel = DriveviewModel;
                break;
        }
    
        //And i return view and viewmodel
        return View(Category + "View", viewmodel)
    }
