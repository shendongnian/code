    MovieCategory newCategory = new MovieCategory
    {
       "Action Movie"
    };
    
    movie.MovieCategories.Add(newCategory);
    
    _movieReviewEntities.Movies.Attach(movie);
    _movieReviewEntities.Entry(movie).State = EntityState.Modified;
    _movieReviewEntities.SaveChanges();
