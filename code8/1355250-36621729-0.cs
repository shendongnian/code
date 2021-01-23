    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateProjet(Projet projet)
    {
        if (ModelState.IsValid)
        {
            db.Projets.Add(projet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(projet);
    }
