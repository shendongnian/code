    IEnumerable<OrderVM> model = db.Timeunits
        .Where(x => x.Week == 1)
        .GroupBy(x => x.OrderID)
        .Select(x => new OrderVM()
        {
            Name = x.FirstOrDefault().Order.Name,
            Employees = x.Select(y => new EmployeeVM()
            {
                Name = y.Employee.Name,
                Hours = y.HoursPerWeek
            })
        }).AsEnumerable();
    return View(model);
