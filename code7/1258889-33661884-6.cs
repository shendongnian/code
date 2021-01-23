    public ActionResult Create()
    {
      var vm= new CreateUserVM();
      vm.EmployeeTypes = GetEmployeeTypes();
      return View(vm);
    }
    public List<SelectListItem> GetEmployeeTypes()
    {
        return new List<SelectListItem>()
        {
            new SelectListItem
            {
                Value = "1",
                Text = "PERM"
            },
            new SelectListItem
            {
                    Value = "2",
                    Text = "Temporary"
                }
        };
    }
