    public ActionResult EditInformation()
    {
        ViewBag.State = new SelectList(db.States, "Id", "StateName");
    
        string userEmail = User.Identity.GetUserName();
    
        Sample model = new SampleModel();     
        model.State = "Melbourne";
    
        return View(model);
    }
