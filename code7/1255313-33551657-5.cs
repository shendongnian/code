    public ActionResult Create()
    {
        var vm = new CreateUserVM(); 
        vm.Departments = GetDeperatements();
        return View(vm);
    }
    private List<SelectListItem> GetDeperatements()
    {
       return db.Departments.Select(s=> new SelectListItem { 
                                        Value=DepartmentId.ToString(),
                                        Text = "DepartmentName"
                                   }).ToList();
    }
