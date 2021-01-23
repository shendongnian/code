    [HttpPost]
    public IActionResult Create(ToDoTask newTask)
    {
        newTask = new ToDoTask(); 
        return RedirectToAction("Index");
    }
