    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateEmployeeViewModel employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employee);
    }
