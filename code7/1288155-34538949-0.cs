    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
    {
        if (ModelState.IsValid)
        {
            // entity is attached to the context, so that it is tracked and its changes saved
            db.Attach(album);
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
        ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
        return View(album);
    }
