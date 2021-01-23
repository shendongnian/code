    public ActionResult Create()
    {
        var vm = new CreateUserVM(); 
        vm.Departments = GetDeperatements();
        return View(vm);
    }
    private List<SelectListItem> GetDeperatements()
    {
       return new SelectList(db.Departments, "DepartmentId", "DepartmentName");
    }
