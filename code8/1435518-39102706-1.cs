    /*public ActionResult Create()
    {
        return View();
    }*/
    // the code above is only necessary if you decide to create your own separate Create View
		
	[HttpPost]
	public ActionResult Create(string toDoItem)
	{				
		Models.ToDoListItem.Create(toDoItem);
        return RedirectToAction("Index");
	}
