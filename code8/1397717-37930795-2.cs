    var nullMovies = allMovies.Where(m=>string.IsNullOrEmpty(m.SomeUniqueMovieProperty));
    
    var distinctNonNullMovies = allMovies.Where(m => !string.IsNullOrEmpty(m.SomeUniqueMovieProperty)).DistinctBy(m => m.SomeUniqueMovieProperty);
    
    var result = nullMovies.Concat(distinctNonNullMovies);
