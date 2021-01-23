    public ActionResult Create()
    {
      var vm = new CreateAdeccoView();
      vm.Clients = new SelectList(db.Client, "ClientID", "ClientName");
      vm.Employees = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
      return View(vm);
    }
