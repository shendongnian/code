    public ActionResult Create()
    {
        var vm = new MedicineMasterVm();
        //The below code is hardcoded for demo. you mat replace with DB data.
        vm.Suppliers= new[]
        {
          new SelectListItem { Value = "1", Text = "Supplier 1" },
          new SelectListItem { Value = "2", Text = "Supplier 2" },
          new SelectListItem { Value = "3", Text = "Supplier 3" }
        };  
        return View(vm);
    }
