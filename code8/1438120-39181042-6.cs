    public ActionResult AssignTask() 
    {
        var model = db.Employees.Select(x => new EmployeeViewModel
        { 
            ID = x.id, 
            Name = x.Name
        }).ToList();
        return View(model);
    }
