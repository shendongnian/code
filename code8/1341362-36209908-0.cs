    public Movie AddMovie(string newMovie, string newGenre, string newActor, string newYear)
    {
        movie = new Movie(newMovie, newGenre, newActor, newYear);
        movieList.Add(movie);
        return movie;
    }
