    var listing = 
        db.Employees.Select(employee => new
        {
            employee,
            payments = employee.Payments.Where(p => p.IsPosted == 1)
        })
        .AsEnumerable() // Switch to LINQ to Objects
        .Select(r =>
        {
            r.employee.Payments = r.payments.ToList();
            return r.employee;
        })
        .ToList();
