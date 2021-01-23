    void Main()
    {
    	var Emp_info = new List<Info>
    		{
    			new Info {Middlename = "Middlename",User_id = "1"}
    		};
    	var Emp_projects = new List<Project>
    		{
    			new Project{Project_id = "1",Project_name = "Project"}
    		};
    	var Emp_locations = new List<LocationInfo>
    		{
    			new LocationInfo{Location = "Location",Project_id="1",User_id = "1"}
    		};
    	
    	/* your code */
    	var query = from e in Emp_info
    	from p in Emp_projects
    	join l in Emp_locations
    		on new { e.User_id , p.Project_id  } equals new { l.User_id, l.Project_id  } into detail
    	from l in detail
    	select new
    	{
    		e.Middlename,
    		p.Project_name,
    		l.Location
    	}; 
    	
    	query.Dump("Join query");
    	/* your code */
    }
    
    class Info
    {
    	public string User_id;
    	public string Middlename;
    }
    
    class Project
    {
    	public string Project_id;
    	public string Project_name;
    }
    
    class LocationInfo
    {
    	public string User_id;
    	public string Project_id;
    	public string Location;
    }
