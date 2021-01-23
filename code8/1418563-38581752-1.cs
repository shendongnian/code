    List<string> properties = new List<string>()
    {
        "EmployeeID",
        "contactNo",
        "Employee.FirstName",  // these is complex property
        "Employee.LastName",   //  these is complex property
    };
    
    Regex rgx = new Regex(@"Employee\.(.*)");
    
    var results = new List<string>();
    foreach(var prop in properties)
    {
        foreach (var match in rgx.Matches(prop))
        {
            results.Add(match.ToString());
        }
    }
