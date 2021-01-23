    class MyLibrary
    {
        public List<Movie> theMovies { get; set; }
    }
    
    public class Movie
    {
        public string name { get; set; } // Changed to lower case, as the json representation.
        public int year { get; set; }
    }
