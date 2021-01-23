    public ActionResult Create()
    {
        ViewBag.EmployeeName = new SelectList(db.EmployeeInformation.ToList(),"Id","Name");
    
        return View();
    } 
    
    [HttpPost]
    public ActionResult Create(DesignationHierarchy designationHierarchy)
    {
        if (ModelState.IsValid)
        {
           using (var db = new MyContext ()) 
             { 
                  db.DesignationHierarchy.Add(designationHierarchy); 
                  db.SaveChanges(); 
             } 
             return RedirectToAction("Index"); 
        }
          View(designationHierarchy); 
     }
