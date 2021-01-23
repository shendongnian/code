    var employees = new List<Employee>
    {
        new Employee
        {
            DeptId = 1,
            Id = 1,
            Name = "JKL"
        },
        new Employee
        {
            DeptId = 1,
            Id = 2,
            Name = "ABC"
        },
        new Employee
        {
            DeptId =  5,
            Id = 3,
            Name = "LMN"
        }
    };
    var query1 = employees.OrderBy(e => e.Name);
    foreach (var employee in query)
    {
        Console.WriteLine(employee.Name); //Prints names
    }
    var query2 = employees
        .AsQueryable()
        .OrderBy("Name");
    foreach (var employee in query2)
    {
        Console.WriteLine(employee.Name); //Prints exact output as foreach loop above.
    }
