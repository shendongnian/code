    var employees = employeeContext.Employees;
    
    foreach (var employee in employees)
    {
        Console.WriteLine("ID: {0}", employee.Id);
        Console.WriteLine("Name: {0}", employee.Name);
        Console.WriteLine("Gender: {0}", employee.Gender);
        Console.WriteLine("City: {0}", employee.City);
    }
