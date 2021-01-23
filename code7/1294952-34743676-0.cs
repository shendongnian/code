    public class Shop
    {
        public string id { get; set; }
        public string title { get; set; }
    }
    
    public class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
    }
    
    public class RootObject
    {
        public List<Shop> Shops { get; set; }
        public List<Movie> movies { get; set; }
    }
