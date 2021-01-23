    public IActionResult Edit(int id)
    {
       var emp = _context.Employees.Where(e => e.EmpId == id).FirstOrDefault();
       if(emp==null)
           return View("NotFound"); //make sure you have this view.
       ViewBag.DeptListName = GetDepartments();
       ViewBag.BldgListName = GetBuildings();
       return View(emp );
    }
