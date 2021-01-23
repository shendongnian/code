    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
        var serviceToDelete = db.Services.Where(s => s.ServiceId == id).Single();
    
        // remove the service option items
        var serviceOptionItems = db.ServiceOptionItems.Where(soi => soi.ServiceOption.ServiceId == serviceToDelete.ServiceId);
        foreach (var serviceOptionItem in serviceOptionItems)
        {
            db.ServiceOptionItems.Remove(serviceOptionItem);
            db.Entry(serviceOptionItem).State = EntityState.Deleted;
        }
    
        // remove the service options
        var serviceOptions = db.ServiceOptions.Where(so => so.ServiceId == serviceToDelete.ServiceId);
        foreach (var serviceOption in serviceOptions)
        {
            db.ServiceOptions.Remove(serviceOption);
            db.Entry(serviceOption).State = EntityState.Deleted;
        }
    
        // remove the contractor services
        var contractorServices = db.ContractorServices.Where(so => so.ServiceId == serviceToDelete.ServiceId);
        foreach (var contractorService in contractorServices)
        {
            db.ContractorServices.Remove(contractorService);
            db.Entry(contractorService).State = EntityState.Deleted;
        }
    
        // remove the service
        db.Services.Remove(serviceToDelete);
    
        // save all changes
        db.SaveChanges();
        return RedirectToAction("Index", new { manage = "yes", mode = "all" });
    }
