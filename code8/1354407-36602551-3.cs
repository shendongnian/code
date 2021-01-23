    public ActionResult Edit(int id)
    {
      var  vm = new VisitorsViewModel();
      vm.Employees = db.Employees.Select(s=> new SelectListItem { 
                           Value=s.EmployeId.ToString(), Text=s.DisplayName }).ToList();
      return View(vm);
    }
