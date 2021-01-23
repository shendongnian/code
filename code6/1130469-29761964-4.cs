    public ActionResult Create()
    {
      ShiftsEmployeesViewModel model = new ShiftsEmployeesViewModel();
      model.Employee = ? // set default selection
      ConfigureCreateModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(ShiftsEmployeesViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureCreateModel(model);
        return View(model);
      }
      .... // map the view model properties to a new instance of the data model, save and redirect
    }
    private void ConfigureCreateModel(ShiftsEmployeesViewModel model)
    {
      var oEmployees = (new CEmployees()).GetActiveEmployees();
      model.EmployeeList = new SelectList(oEmployees, "Id", "FullName");
    }
