    public class Image
    {
        public string content { get; set; }
    }
    public class Feature
    {
        public string type { get; set; }
        public int maxResults { get; set; }
    }
    public class Request
    {
        public Image image { get; set; }
        public List<Feature> features { get; set; }
    }
    public class RootObject
    {
        public List<Request> requests { get; set; }
    }
