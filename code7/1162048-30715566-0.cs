    public IList<Movie> GetMovieTimeTable(DateTime date)
    {
       var result = movierepo.Movies
         .Where(m=>timetablerepo.TimeTables.Where(tt=>tt.StartTime.Date==date.Date)).Select(tt=>tt.MovieId).Contains(m.MovieId))
         .ToList();
       return result;
    }
