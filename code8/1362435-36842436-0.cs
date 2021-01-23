    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            // Data access and mapping of domain to vm entities here. 
            var movieListModel = new MovieListModel();
            return View(movieListModel);
        }
    
        public ActionResult Increment(IncrementMovieCountModel model)
        {
            // Put breakpoint here and you can check the value are correct
            var incrementValue = model.IncrementValue;
            var movieId = model.MovieId;
    
            // Update movie using entity framework here
            // var movie = db.Movies.Find(id);
            // movie.Number = movie.Number + model.IncrementValue;
            // db.Movies.Save(movie);
    
            // Now we have updated the movie we can go back to the index to list them out with incremented number
            return RedirectToAction("Index");
        }
    
    }
