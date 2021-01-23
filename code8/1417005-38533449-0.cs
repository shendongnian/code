    public IActionResult Index()
    {
        var list=_context.Employees
                     .Select(s=> new EmployeeViewModel { 
                                                         EmpId =s.EmpId ,
                                                         EmpFirstName=s.EmpFirstName,
                                                         EmpLastName=s.EmpLastName,
                                                         EmpPhoneNumber=s.EmpPhoneNumber,
                                                         EmpStartDate=s.EmpStartDate,
                                                         DeptName=s.DeptName
                                                       }).ToList();
        return View(list);
    }
