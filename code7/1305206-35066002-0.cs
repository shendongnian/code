    public class RootObject
    {
        public List<int> categories { get; set; }
        public List<Series> series { get; set; }
    }
    public class Series
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }
