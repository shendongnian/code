    public class Method
    {
        public string title { get; set; }
        public string type { get; set; }
        public string password { get; set; }
        public string stepUp { get; set; }
    }
    public class Response
    {
        public Dictionary<string, Method> methods { get; set; }
    }
