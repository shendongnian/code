    public List<Phone> GetListOfPhones(Employee emp)
    {
       List<Phone> records = new List<Phone>();
       string query = BuildQueryByEmployeePosition(emp);
             
       var rawItems = QuerySPList(query);
    
       foreach (SPListItem item in rawItems)
       {
            //business logic 
       }
       return records;
    }
    
    private string BuildQueryByEmployeePosition(Employee emp) 
    {
        if (emp.Positions.Count == 1 && emp.Positions[0] == "Regular")
            return "";// some querystring    
    
        if (emp.Positions.Count == 1 && emp.Positions[0] == "OfficeDirector")
            return "";// some querystring    
    
        if (emp.Positions.Count == 1 && emp.Positions[0] == "Admin")
            return "";// some querystring    
    
        if (emp.Positions.Count == 2 && emp.Positions.Contains("Regular") && emp.Positions.Contains("OfficeDirector"))
            return "";// some querystring    
        return ""; // some default query
    }
