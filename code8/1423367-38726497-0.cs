    public static Movie getMovieByName(string name)
    {
        var movie = MovieRepository.Movies.SingleOrDefault(m => m.name == name);
        if(movie != null)
        {
            return movie;
        }
        else
        {
            throw new InvalidMovieException(name);
        }
    }
