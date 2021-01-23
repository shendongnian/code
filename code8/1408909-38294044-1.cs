    public ActionResult SpecificEmpDetails(string Id)
    {
        CustomerBAL customer = new CustomerBAL();
        Customer custs = customer.Employees.Single(emp => emp.EmpID.ToString() == Id);
        ViewBag.Customers = custs;
        return View("EmpDetails");
    }
