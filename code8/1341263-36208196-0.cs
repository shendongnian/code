    [HttpPost]
    public ActionResult index (...)
    {
		var cachedStaff = db.Employee.toList(); 
		Session["stafflist"] = cachedStaff;
    }
	
