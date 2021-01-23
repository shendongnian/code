    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Entity entity)
    {
        if (ModelState.IsValid)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(entity);
    }
