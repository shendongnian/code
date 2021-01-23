	[HttpPost]
    public ActionResult Index (...)
    {
		var cachedStaff = Session["stafflist"] as List<Employee>();
		
		// TODO: check cachedStaff for null, for when someone posts after 
		// their session expires or didn't visit the Index page first.
		
		var selectedStaff = cachedStaff.Where(..).ToList();
		
		// the rest of your code
	}
