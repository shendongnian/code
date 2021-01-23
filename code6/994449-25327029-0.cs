    public ActionResult Edit(Movie updatedMovie)
    {
      if (ModelState.IsValid)
      {
       //db=your entities context
       //here you will get instance of record from db that you want to update
       Movie movie = db.Movie.Find(updatedMovie.Id);
       TryUpdateModel(movie);
       ctx.SaveChanges();
       return RedirectToAction("Index");
      }
      return View(movie);
    }
