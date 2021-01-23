    public ActionResult Index(string searchBy, string orderBy, string orderDir)
    {
        var query = fca.GetResultsByFilter(searchBy);
    
    	switch (orderBy)
    	{
    		case "Campus":
    			query = query.OrderByWithDirection(s => s.Campus, orderDir);
    			break;
    		case "Student Name":
    			query = query.OrderByWithDirection(s => s.Student_Name, orderDir);
    			break;
    		case "Course Count":
    			query = query.OrderByWithDirection(s => s.Course_Count, orderDir);
    			break;
    	}
    	
    	if (orderBy == "Campus" && orderDir == "Asc")
    	{
    		// The Campus Asc case was also ordered by Student_Name in the question.
    		query = query.ThenBy(s => s.Student_Name);
    	}
    }
