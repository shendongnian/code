    //get all movies and return to view
    public ActionResult AllMovies()
    {
        List<Movie> movies = db.Movies.ToList();
    
        if (movies == null || movies.Count==0)
        {
            return HttpNotFound();
        }
    
        return View(movies);
    }
