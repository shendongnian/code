    public class Movie
    {
        public string Name { get; set; }
        public virtual ObservableCollection<Category> Categories { get; set; }
    }
    public class Category
    {
        public string Name {get;set;}
        public virtual Movie Movie {get;set;}
    }
