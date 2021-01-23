    public class Field
    {
        public string defaultValue { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }
    public class Presentation
    {
        public List<Field> fields { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public Presentation presentation { get; set; }
        public string thumbnail { get; set; }
        public string updated { get; set; }
        public Dictionary<string, string> userData { get; set; }
    }
