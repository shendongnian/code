    public JsonResult GetMovieTitles(string movie_name)
    {
        MbdbContext db = new MbdbContext();
        List<string> MovieTitle = new List<string>();
        foreach (var item in db.Movies.Where(m => m.MovieName.Contains(movie_name)).ToList())
        {
            MovieTitle.Add(item.MovieName.ToString());
        }
        return Json(MovieTitle, JsonRequestBehavior.AllowGet);
    }
