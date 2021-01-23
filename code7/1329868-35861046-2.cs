    public ActionResult Test(string clientID, string employeeID)
    {
        // filter your data based on the parameters, for example
        var data = table.Where(x => x.Emp_id == EmployeeID).GroupBy(x => x.Name).Select( ..... );
        SearchVM model = new SearchVM
        {
            ClientID = clientID,
            EmployeeID = employeeID,
            Groups = data
        };
        return View(model);
    }
