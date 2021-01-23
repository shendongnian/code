    public async ActionResult()
    {
      var model = new Company();
      using (var db1 = new DbContext)
      using (var db2 = new DbContext)
      {
        await model.employees = db1.Employees.ToListAsync();
        await model.managers = db1.Managers.ToListAsync();
      return View(model);
    }
