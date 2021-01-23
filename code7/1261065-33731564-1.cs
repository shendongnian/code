    public ActionResult Index()
    {
         // This is just dummy code
         HeatingViewModel model1 = new HeatingAreaViewModel();
         // Populate the properties
         model1.HeatImage = new HeatImage();
         // Populate the properties
         model1.HeatingArea = new HeatingArea();
    
         HeatingViewModel model2 = new HeatingAreaViewModel();
         // Populate the properties
         model2.HeatImage = new HeatImage();
         // Populate the properties
         model2.HeatingArea = new HeatingArea();
    
         // Now pass this list to the view
         List<HeatingViewModel> models = new List<HeatingViewModel>();
    
         return View(models);
    }
