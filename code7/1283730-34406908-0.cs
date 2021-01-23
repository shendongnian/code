    if (ModelState.IsValid)
    {
        site.SiteKey = System.Guid.NewGuid();
        db.Sites.Add(site);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
