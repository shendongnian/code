    public ActionResult Create()
    {
        ViewBag.EmployeeName = new SelectList(db.EmployeeInformation.ToList(), "Id", "Name");
        ViewBag.LineManagerName = new SelectList(db.EmployeeInformation.ToList(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public ActionResult Create(DesignationHierarchy designationHierarchy)
    {
        if (ModelState.IsValid)
        {
            db.DesignationHierarchy.Add(designationHierarchy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(designationHierarchy);
    } 
    public ActionResult Edit(decimal id)
    {
        DesignationHierarchy designationHierarchy = db.DesignationHierarchy.Find(id);
        ViewBag.EmployeeName = new SelectList(db.EmployeeInformation.ToList(), "Id", "Name");
        ViewBag.LineManagerName = new SelectList(db.EmployeeInformation.ToList(), "Id", "Name");
    
        return View(designationHierarchy);
    }
    [HttpPost]
    public ActionResult Edit(DesignationHierarchy designationHierarchy)
    {
        if (ModelState.IsValid)
        {
            db.Entry(designationHierarchy).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(designationHierarchy);
    }
    
  
  
