    public ActionResult Index()
    {
         TestViewModel model = new TestViewModel();
         
         model.Statuses = new List<Status>();
         model.Statuses.Add(new Status { Id = 1, Name = "Status 1" });
         model.Statuses.Add(new Status { Id = 2, Name = "Status 2" });
         model.Statuses.Add(new Status { Id = 3, Name = "Status 3" });
    
         return View(model);
    }
