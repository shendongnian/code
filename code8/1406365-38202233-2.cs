    using (var ctx = new ApplicationDbContext(schemaName))
    {
    	var company = ctx.Companies.FirstOrDefault(e => e.ID == 42);
    	if(company == null)
    		throw new Exception();
    		
    	var empl = company.Employees.Where(e=> e.Status == Live).Select(e=>
    		new EmployeeInfo{
    			ID = e.ID,
    			FName = e.FName,
    			//TODO
    			DesignationString = e.Designation != null ? e.Designation.ComboValue : string.Empty,
    			//TODO
    		
    		});
    		
    	return empl.ToList();
    }
