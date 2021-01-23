    private List<Employee> CachedStaff
    {
        get { return Session["stafflist"] as List<Employee>; }
        set { Session["stafflist"] = value; }
    }
    [HttpGet]
    public ActionResult Index (...)
    {
		CachedStaff = db.Employee.toList(); 
    }
	
	[HttpPost]
    public ActionResult Index (...)
	{
        // TODO: this will throw a NullReferenceException when
        //  the staff list is not cached, see above.
		var selectedStaff = CachedStaff.Where(..).ToList();
		
		// the rest of your code
	}
