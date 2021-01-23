    public IList<Movie> GetMovieTimeTable(DateTime date)
    {
       var result = movierepo.Movies
         .Join(timetablerepo.TimeTables,m=>m.MovieId,tt=>tt.MovieId,(m,tt)=>m)
         .Distinct()
         .ToList()
       return result;
    }
