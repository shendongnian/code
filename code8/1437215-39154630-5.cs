    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public int code { get; set; }
    }
    public class Body
    {
        public Error error { get; set; }
    }
    public class Respons
    {
        public string info { get; set; }
        public Body body { get; set; }
    }
    public class RootObject
    {
        public List<Respons> responses { get; set; }
    }
