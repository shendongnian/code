    public class Match
    {
        public List<object> value { get; set; }
    }
    public class Snippets
    {
        public List<Match> match { get; set; }
    }
    public class RootObject
    {
        public Snippets snippets { get; set; }
    }
