     public static HashSet<Movie> sd = new HashSet<Movie>();
        public static IList<Movie> getMovieRecommendations(Movie movie, int numTopRatedSimilarMovies)
        {
            sd.Add(movie);
            foreach (Movie m in movie.getSimilarMovies())
            {
                if (!sd.Contains(m))
                    getMovieRecommendations(m, -1);
            }
            if(numTopRatedSimilarMovies > -1)
                return sd.OrderByDescending(o => o.rating).Take(numTopRatedSimilarMovies).ToList();            
            return null;
        }
