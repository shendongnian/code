    public IActionResult Create()
    {
        var vm = new MyViewModel();
        vm.Employees = new SelectList(GetEmployees(),"Id","FirstName");
        return View(vm);
    }
    public IEnumerable<Employee> GetEmployees()
    {
      return new List<Employee>
      {
        new Employee { Id=1, FirstName="Shyju"},
        new Employee { Id=2, FirstName="Bryan"}
      };
    }
