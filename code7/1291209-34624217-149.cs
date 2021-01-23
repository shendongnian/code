    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.Employees = new SelectList(GetEmployees(),"Id","FirstName");
        return View(vm);
    }
    public IEnumerable<Employee> GetEmployees()
    {
        // hard coded list for demo. 
        // You may replace with real data from database to create Employee objects
        return new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Shyju" },
            new Employee { Id = 2, FirstName = "Bryan" }
        };
    }
