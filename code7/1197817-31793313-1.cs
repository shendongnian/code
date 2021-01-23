    public ActionResult Index()
    {
        var movies = from m in db.Movies.Include(b => b.Producer) 
                     select m;
        return View(movies.ToList());
    }
