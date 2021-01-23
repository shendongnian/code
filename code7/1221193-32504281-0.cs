    public class User
    {
        public string Name { get; set; }
    }
    public class Movie
    {
        public string Title { get; set; }
    }
    public class Rating
    {
        public User RatingUser { get; set; }
        public Movie RatingMovie { get; set; }
    }
