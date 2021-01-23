    public async ActionResult()
    {
      var model = new Company();
      using (var db1 = new DbContext)
      using (var db2 = new DbContext)
      {
        var task1 = model.employees = db1.Employees.ToListAsync();
        var task2 = model.managers = db1.Managers.ToListAsync();
        await Task.WhenAll(task1, task2);
      }
      return View(model);
    }
