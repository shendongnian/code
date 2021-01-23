    public ActionResult Create() 
    { 
      scenario = TempData["CreateCopy"] as Scenario; 
      if (scenario == null) 
      { 
        scenario = new Scenario(User.Identity.Name); 
      }
