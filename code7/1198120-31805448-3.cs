     public ActionResult Index()
        {
    
    //you need to populate your viewmodel with data from database
    SingleViewModel model=new SingleViewModel();
    
    model.ListHome=GetHomeData().ToList();
    model.ListCar=GetCarData().ToList();
    model.AboutMe=GetAboutMeData().ToList();
    
           //pass your model to view
    
            return View(model);
        }
