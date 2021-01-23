    public class Movie
    {
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
    public class Category
    {
        public string Name {get;set;}
        public virtual ICollection<Movie> Movies {get;set;}
    }
