    List<Employee> employeeFilterList = new List<Employee>();
    
    for(int a = validEmployeeList.Count; --a >= 0; )
    {
        for(int b = existingFieldMappingList.Count; --b >= 0; )
        {
            Employee aEmployee = validEmployeeList[a];
            Employee bEmployee = validEmployeeList[b];
            if (aEmployee.EmployeeId != bEmployee.EmployeeId)
                continue;
            if (aEmployee.FirstName != bEmployee.FirstName)
                continue;
            if (aEmployee.Age != bEmployee.Age)
                continue;
            if (aEmployee.LastName != bEmployee.LastName)
                continue;
    
            employeeFilterList.Add(aEmployee);
        }
    }
