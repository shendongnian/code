    public class Movies
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class MyViewModel
    {
        public List<Movies> movies { get; set; }
    }
