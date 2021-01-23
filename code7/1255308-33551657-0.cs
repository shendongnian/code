    public ActionResult Create()
    {
        ViewBag.DepartmentId = GetDeperatements();
        return View();
    }
    [HttpPost]
    public ActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        ViewBag.DepartmentId = GetDeperatements();
        return View(employee);
    }
    private List<SelectListItem> GetDeperatements()
    {
       return new SelectList(db.Departments, "DepartmentId", "DepartmentName");
    }
