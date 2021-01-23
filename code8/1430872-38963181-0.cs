    [HttpPost] //since you using POST
    public JsonResult GetMovieTitles(string movie_name)
    {
        MbdbContext db = new MbdbContext();
        //also, it's better refactor to that way:
        List<string> MovieTitle = db.Movies
           .Where(m => m.MovieName.Contains(movie_name))
           .Select(x=>x.MovieName.ToString()).ToList()
    
        return Json(MovieTitle);
    }
