    public ActionResult DisplayProjectTask(string projectId, int? page)
    {    
        var model = new FooViewModel();
        model.Tasks = dbHelper.GetProjectTaskList(projectId).ToPagedList(page ?? 1, 10);
        model.EmpIds = dbHelper.GetTaskEmployeesId(projectId);           
        return View(model);
    }
