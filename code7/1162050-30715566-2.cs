    public IList<Movie> GetMovieTimeTable(DateTime date)
    {
       var result = movierepo.Movies
         .Join(timetablerepo.TimeTables,m=>m.MovieId,tt=>tt.MovieId,
           (m,g)=>new Movie{
             MovieId=m.MovieId,
             ... rest of properties here ...
             TimeTables=g.Where(tt=>tt.StartDate.Date=date.Date).ToList()
           })
         .Where(m=>m.TimeTables.Any())
         .ToList();
       return result;
    }
