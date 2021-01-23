    using (YourDbContext ctx = new YourDbContext())
    {
        Employee emp = new Employee();
        // set the values for "emp"
      
        emp.EmployeeDetail = new EmployeeDetails();
        // set the employee details
        ctx.SaveChanges();
    }
