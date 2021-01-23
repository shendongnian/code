    var result = list
        .SelectMany(x =>
            new [] { new Person { Name = x.Name, Department = x.Department, Gender = x.Gender, EmpID = x.EmpID }}
            .Concat(x.Employees))
        .GroupBy(x => x.EmpID) //Group by employee ID
        .Select(g => g.First()) //And select a single instance for each unique employee
        .ToList();
