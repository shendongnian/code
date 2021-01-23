     var EmployeeCollection=Helper.GetEmployees();
        foreach(var employee in  EmployeeCollection)
        {
        foreach(var prop in employee.GetType().GetProperties())
        {
        string val=(string)prop.GetValue(employee,null);
        if(String.IsNullOrEmpty(val)) Helper.Log(prop.Name);
        }
    }
