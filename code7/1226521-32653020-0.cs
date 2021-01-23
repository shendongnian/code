    [HttpPost]
    public ActionResult Add(Employee employee)
    {
        using (var context = new MyContext())
        {
            // add the employee object
            context.Employees.Add(employee);
            // save changes
            context.SaveChanges();
            // the id will be available here!
            int employeeId = employee.Id;   
            // ..so perform your Redirect, _
            // and pass employee.Id as a parameter to the action       
            return RedirectToAction("Index", "Employee", new { id = employeeId });            
        }
    }
