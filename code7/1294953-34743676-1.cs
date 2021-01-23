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
    
    public class RequestDetailsCollection
    {
        public List<Shop> Shops { get; set; }
        public List<Movie> movies { get; set; }
    }
