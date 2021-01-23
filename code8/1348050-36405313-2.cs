    public ActionResult Create()
    {
    
      MyCreateVM viewModel = new MyCreateVM();
    
      viewModel.ActivityList = myActivityService.GetAll();
      viewModel.City = myCityService.GetAll();
      viewModel.RegList  = myRegService.GetAll();
    
      return View(viewModel);
    }
