    public ActionResult Create()
    {
        var oEmployees = new CEmployees();
        oEmployees.GetActiveEmployees();
        var shiftsEmployees = new ShiftsEmployeesViewModel
        {
            Employee = new CEmployee(),
            Shift = new CShift(),
            Employees = oEmployees;
        };
        return View(shiftsEmployees);
    }
