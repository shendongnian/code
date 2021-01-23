    using (dbContext context = new dbContext())
    {
    	Employee emp = new Employee();
    
    	emp.EmpName = "John";
    	emp.EmployeeDetails = new EmployeeDetails 
    	{
    		//details fields
    	};
    	
    	context.SaveChanges();
    }
