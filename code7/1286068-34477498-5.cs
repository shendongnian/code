    [HttpPost]
    public ActionResult Create(TaskInstanceViewModel model)
    {
        if (ModelState.IsValid)
        {
            var taskinstance = new TaskInstance { DueDate = model.DueDate ,
                                                  TaskId=model.SelectedTask };
            db.TaskInstance.Add(taskinstance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        model.TaskList = db.Task.ToList().Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name
        }).ToList();
        return View(model);
    }
