    public ActionResult Index()
    {
        var movies = from m in db.Movies.Include("Producer") 
                     select m;
        return View(movies.ToList());
    }
