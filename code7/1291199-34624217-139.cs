    public IActionResult Create()
    {
        var vm = new MyViewModel();
       
        var group1 = new SelectListGroup { Name = "Dev Team" };
        var group2 = new SelectListGroup { Name = "QA Team" };
        var employeeList = new List<SelectListItem>()
        {
            new SelectListItem() { Value = "1", Text = "Shyju", Group = group1 },
            new SelectListItem() { Value = "2", Text = "Bryan", Group = group1 },
            new SelectListItem() { Value = "3", Text = "Kevin", Group = group2 },
            new SelectListItem() { Value = "4", Text = "Alex", Group = group2 }
        };
        vm.Employees = employeeList;
        return View(vm);
    }
