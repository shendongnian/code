    public ActionResult Index()
    {
        var model = new MovieViewModel() 
        {
            MovieCollection = db.Movies.ToList(),
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(Movie movie)
    {
        if (ModelState.IsValid)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        var model = new MovieViewModel()
        {
            Movie = movie,
        };
        return View(movie);
    }
