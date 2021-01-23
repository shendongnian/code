    var genres= context.Genres.Where(g=>genresids.Contains(g.GenreId))
    var artist=context.FirstOrDefault(); //Find an artirst
    foreach(var genre in genres)
    {
       artist.Genres.Add(genre);
    }
   
    context.SaveChanges();
