    partial class MovieRentalSys
    {
        public Dictionary<string, Movie> movieList;
        ...
        //Will take movie form text as arguments to create new movie in list
        public Movie AddMovie(string newMovie, string newGenre, string newActor, string newYear)
        {
            movie = new Movie(newMovie, newGenre, newActor, newYear);
            movieList.Add(newMovie, movie);
            return movie;
        }
        public List<Movie> DeleteMovie(string movieName)
        {
            //needs to be made
        }
        ...
    }
