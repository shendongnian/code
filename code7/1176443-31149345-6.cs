    [HttpPost]
    public ActionResult EditUserSubmit(NV.Tax.SST.Gateway.MVC.Models.AdministrationModel model)
    {
        string process = (model.ProcessType == "Processed") ? "P" : "B";
        DB.Entities.user users = db.users.Where(m => m.username == model.UserName).FirstOrDefault();
        users.password = model.Password;
        users.processtype = process;
        db.SaveChanges();
    
        return RedirectToAction("Manager");
    }
