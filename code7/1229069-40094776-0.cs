    private ActionResult GetEmployeesForDropDown()
    {
        var lstEmployees = new[] 
        {   
            new Employee { Id = 1, Name = "Emp1" }, 
            new Employee { Id = 2, Name = "Emp2" }, 
            new Employee { Id = 3, Name = "Emp3" } 
        };
        var selectList = new SelectList(lstEmployees, "Id", "Name", 0);  
        //Here 0 is the selectedIndex which we are assigning to dropdownlist, we can pass value we want here to set the index
        ViewData["Employees"] = selectList;  
        // dropdownlist datasource which is a employeelist is assigned to a ViewData here
        return View();
    }
