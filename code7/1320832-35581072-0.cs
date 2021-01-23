    if (ModelState.IsValid)
    {
        db.Registrations.Attach(registration); // attach in the Unchanged state
        db.Entry(registration).Property(r => r.Date).IsModified = true;
        // Date field is set to Modified (entity is now Modified as well)
        db.SaveChanges();
        return RedirectToAction("Index");
    }
