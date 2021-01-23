    [HttpGet]
    public ActionResult MyAction1()
    {
        var model = new EmployeeStaffViewModel();
        model.Staff = context.Staff.Select(StaffModel.Project);  //Select Staff to StaffModel List
        model.Employee = context.Employee.Select(EmployeeModel.Project); //Select Employee to EmployeeModel List
        return View(model);
    }
