    public async ActionResult()
    {
      var model = new Company();
      using (var db1 = new DbContext)
      using (var db2 = new DbContext)
      {
        var task1 = db1.Employees.ToListAsync();
        var task2 = db1.Managers.ToListAsync();
        await Task.WhenAll(task1, task2);
        model.employees = task1.Result;
        model.managers = task2.Result;
      }
      return View(model);
    }
