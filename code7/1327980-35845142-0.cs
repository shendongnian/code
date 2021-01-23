    private void AddSubordinate(Employee parentEmployee)
    {
        var subs = employeeFromDb.Where(m => m.ManagerNumber == parentEmployee.EmployeeNumber).ToList();
        employeeFromDb.Remove(parentEmployee);
    
        if (subs.Count != 0)
            parentEmployee.Subordinates = new List<Employee>(subs);
    
        if (employeeFromDb.Count == 0)
            return;
    
        AddSubordinate(employeeFromDb.First());
    }
