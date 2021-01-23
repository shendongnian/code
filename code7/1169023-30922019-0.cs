    IList<Employee> GetEmployees(Employee manager)
    {
        var result = new List<Employee>();
        var employees = _employeeDb.Employees
                                   .Where(e => e.ManagerEmployeeNumber == manager.EmployeeNumber)
                                   .ToList();
        foreach (var employee in employees)
        {
            result.Add(employee);
            result.AddRange(GetEmployees(employee));
        }
        return result;
    }
