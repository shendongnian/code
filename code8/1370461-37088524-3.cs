    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ProjectId, CoverLetter")] Application application)
    {
        if (ModelState.IsValid)
        {
            applicatio.UserId = User.Identity.GetUserId(); // set the user here
            db.Applications.Add(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(application);
    }
