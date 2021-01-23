    [HttpGet]
    public ActionResult Index (...)
    {
		var cachedStaff = db.Employee.toList(); 
		Session["stafflist"] = cachedStaff;
    }
	
