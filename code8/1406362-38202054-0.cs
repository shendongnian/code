    using (var ctx = new ApplicationDbContext(schemaName))
    {
    	var loadValues = ctx.CValue.Where(c => c.Company == comp).ToList();
    	return ctx
    		.Employee
    		.Where(a => a.Company == comp && a.Status == Live)
    		.Select(item => new Employee
    		{
    			Id = item.Id,
    			Code = item.Code,
    			FName = item.FName,
    			DateOfJoining = item.DateOfJoining,
    			Category = item.Category,
    			Designation = item.Designation,
    			Department = item.Department,
    			DesignationString = loadValues.Where(c => c.CompanyId == comp && c.Id == item.Designation ?? 0).FirstOrDefault(c => c.ComboValue);
    			DepartmentString = loadValues.Where(c => c.Company == comp && c.Id == item.Department ?? 0).FirstOrDefault(c => c.ComboValue);
    		});
    }
