    public static class LibMethods
    {
        public static List<Movie> get_movies(Entities MovieEntity) //Model in Library Class
        {
           var movies = from m in MovieEntity.Movie
                          select m;
            return movies.ToList();
        }
    }
