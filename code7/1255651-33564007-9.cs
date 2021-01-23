    public ActionResult Edit(decimal id)
    {
        ViewBag.EmployeeName = new SelectList(db.EmployeeInformation.ToList(), "Id", "Name",designationHierarchy);
    
         using (var db = new MyContext()) 
         { 
                return View(db.DesignationHierarchy.Find(id)); 
         } 
    }
    [HttpPost]
    public ActionResult Edit(DesignationHierarchy designationHierarchy)
    {
        if (ModelState.IsValid)
        {
          using (var db = new MyContext()) 
           { 
            db.Entry(designationHierarchy).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
           }
        }
        return View(designationHierarchy);
    }
