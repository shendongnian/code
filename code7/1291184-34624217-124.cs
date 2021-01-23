    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.EmployeesList = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Shyju" },
            new Employee { Id = 2, FullName = "Bryan" }
        };
        return View(vm);
    }
