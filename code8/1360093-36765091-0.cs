    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public ActionResult Create([Bind(Include = "IdeId,Emne,Forslag")] Ide ide)
    {
        if (ModelState.IsValid)
        {
            ide.UserId = User.Identity.GetUserId()
            db.Ides.Add(ide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ide);
    }
