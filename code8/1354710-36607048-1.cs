    public List<Movie> GetMovies(DateTime date)
    {
        using (EntityContext db = new EntityContext())
        {
            List<Movie> movieList = db.Movies.Include("Show")
                .Where(x => x.Shows.Any(x => x.DateTime.Date == date.Date));
            return movieList;
        }
    }
