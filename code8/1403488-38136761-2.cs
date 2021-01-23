    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Archive (int ID)
    {
        // Get the original 
        ProductNote model = db.ProductNote.FirstOrDefault(x => x.ID == ID);
        // If the user has the permission to archive and the model is not null
        model.Archived = true;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
