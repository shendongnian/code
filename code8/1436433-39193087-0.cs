    public class User
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Movie> FavouriteMovies { get; set; }
    }
