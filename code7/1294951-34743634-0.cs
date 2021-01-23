    public class RequestDetailsCollection 
    {
        public Shop[] Shops { get; set; }
        public Movie[] movies { get; set; }
    }
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
