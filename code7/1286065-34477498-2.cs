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
        return View(model);
    }
