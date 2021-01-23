    public ActionResult EditUserSubmit(NV.Tax.SST.Gateway.MVC.Models.AdministrationModel model)
    {
        string process;
        string name = Url.RequestContext.RouteData.Values["id"].ToString();
        process = (model.ProcessType == "Processed") ? "P" : "B";
        DB.Entities.user users = db.users.Where(m => m.username == name).FirstOrDefault();
        users.password = model.Password;
        users.processtype = process;
        db.SaveChanges();
    
        return RedirectToAction("Manager");
    }
