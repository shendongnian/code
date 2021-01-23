    string[,] employeeArray = { { "john", "MBA#MBA#BE#MBA#BE" }, { "jan", "MS#MSC#MBA" } };
    List<Employee> employees = new List<Employee>();
    for (int i = 0; i < employeeArray.GetLength(0); i++)
    {
        Employee employee = new Employee(employeeArray[i,0]);
        foreach (var degree in employeeArray[i, 1].Split('#'))
        {
            employee.Degrees.Add(degree);
        }
        employees.Add(employee);
    }
    foreach (var e in employees)
    {
        Console.WriteLine(e.Name + " " + string.Join(" ", e.Degress));
    }
