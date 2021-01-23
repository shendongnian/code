         public class Program
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Investor
    {
        public string name { get; set; }
        public List<Program> programs { get; set; }
    }
    public class RootObject
    {
        public List<Investor> investors { get; set; }
    }
