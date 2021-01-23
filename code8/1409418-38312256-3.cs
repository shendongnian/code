    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateEmployeeViewModel vm)
    {
        if (ModelState.IsValid)
        {
    var model = new Employee{
       //your logic here for example
        employeename = vm.employeename,
        employeepassword = vm.employeepassword
       } 
            _context.Employees.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employee);
    }
