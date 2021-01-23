    Site site = db.Sites.Find(id);
    if (site == null)
    {
        return HttpNotFound();
    }
    db.Entry(site).Reference(p => p.Version).Load(); 
    return View(site);
