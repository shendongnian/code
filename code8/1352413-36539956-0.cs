    var employees = context.Employee.ToList();
    var data = employees.Where(t => t.EmployeeCode.Trim() == Model.EmployeeCode.Trim())
                        .Select(t => t.EmployeeCode)
                        .FirstOrDefault();
    
    if(data != null)
    {
       //Rest other code.
    }
