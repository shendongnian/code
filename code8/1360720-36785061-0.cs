        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            var dbMovie = db.Movies.find(movie.id);
            db.Movies.Remove(dbMovie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
