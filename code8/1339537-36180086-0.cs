    var query = Context.Employees.AsQueryable();
    if (!IncludeArchived)
    {
        query = query.Where(e => e.Status.employeeStatusId != 5);
    }
    switch (selectedColumnValue)
    {
         // ...
    }
