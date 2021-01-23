    [HttpPost]
    public ActionResult Default(int cono, string firstName, string lastName, string branch, string salesRep, bool statustype)
    {
        //Query the Search Options with the database and return the matching results to the Results Page.
        var results = EmployeeDb.EmployeeMasters.Where(e => e.StatusFlag == statustype);
    
        results = results.Where(e => e.CompanyNumber == cono);
        if (!branch.IsNullOrWhiteSpace())
        {
            results = results.Where(e => e.Branch == branch);
        }
        if (!firstName.IsNullOrWhiteSpace())
        {
            results = results.Where(e => e.FirstName == firstName);
        }
        if (!lastName.IsNullOrWhiteSpace())
        {
            results = results.Where(e => e.LastName == lastName);
        }
    
        return Results(results.ToList()); 
    }
