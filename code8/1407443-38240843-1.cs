    using (dbcontext ctx = new dbcontext())
    {
        ctx.Connection.Open();
        var result = (from e in ctx.Employees
                      join p in ctx.Payments on e.employeeId equals p.employeeId
                      where p.IsPosted == 1
                      select new
                      {
                          Employee = e,
                          Payments = p
                      }).ToList();
        ctx.Connection.Close();
    }
