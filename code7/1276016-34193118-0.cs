    public ActionResult Create()
    {
       var vm = new Student();
       return View(vm);
    }
    [HttpPost]
    public ActionResult Create(Student model)
    {
       //You can check model.IsNew and model.FirstName properties here
       // TO DO : Save and Redirect to a success message action method
       // Ex : return RedirectToAction("SavedSuccessfully");
    }
