    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Domain domain) {
        var rep = new Repository<Site>();
        //Assuming Repository has some means of retrieving entities,
        //get the site from repository using a common identifier
        var siteRecord = rep.FirstOrDefault(s => s.id == domain.id);
        if(siteRecord !=null) {
            //if a record is found, remove it from repository
            rep.Delete(siteRecord);
        }
        return View(domain);
    }
