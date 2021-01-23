    public class Response
    {
        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string url { get; set; }
        public string lyrics_id { get; set; }
        public int genre { get; set; }
    }
    
    public class RootObject
    {
        public List<Response> response { get; set; }
    }
