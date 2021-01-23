    [HttpPost]
    public ActionResult Create(CreateAdeccoView model)
    {
      if(ModelState.IsValid)
      {
          AdeccoView view = new AdeccoView();
          view.EmployeeId=model.EmployeeID;
          view.ClientID=model.ClientID;
          //Don't forget to map other properties as well.
    
         db.AdeccoView.Add(adeccoView);
         db.SaveChanges();
         return RedirectToAction("Index");
    
      }      
      model.Clients = new SelectList(db.Client, "ClientID", "ClientName");
      model.Clients = new SelectList(db.Employees, "ClientID", "ClientName");
      return View(model);
    }
