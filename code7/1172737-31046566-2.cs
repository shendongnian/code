    public ActionResult Create()
    {
         PersonViewModel model = new PersonViewModel();
         
         // Get a list of all the people
         // I can't remember how to use Entity Framework to get a list of all the people,
         // it's something like the code below
         model.Persons = db.Persons;
         
         return View(model);
    }
