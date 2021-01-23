    public ActionResult EditInformation()
    {
        ViewBag.State = new SelectList(db.States, "ID", "StateName", /*Melbourne's ID*/);
        string userEmail = User.Identity.GetUserName();
        Sample model = new SampleModel();     
        model.State = "Melbourne";
    return View(model);
    }
