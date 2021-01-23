    using (var ctx = new myEntities())
    {
        var employyes = from x in ctx.EmployeeTable select new
        {
            id = x.Id,
            name = x.Name
        }
    }
