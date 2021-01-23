    public List<Employee> CheckIfExists(List<string> nameList)
    {
        if (nameList == null)
        {
            return null;
        }
    
        string inClause = "";
    
        foreach (var item in nameList)
        {
            inClause = string.Format("{0},{1}", inClause, item);
        }
    
        return db.employee.SqlQuery("SELECT * FROM employee WHERE employee.Name IN (@p0)", inClause).ToList(); 
    }
