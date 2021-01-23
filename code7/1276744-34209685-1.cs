    public ActionResult Create()
    {
      var vm = new CreateAdeccoView();
      vm.Clients = new SelectList(db.Client, "ClientID", "ClientName");
      vm.Clients = new SelectList(db.Employees, "ClientID", "ClientName");
      return View(vm);
    }
