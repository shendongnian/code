    public class Object
    {
        public string OldData { get; set; }
        public string NewData { get; set; }
        public string AccidentNumber { get; set; }
    }
    public class RootObject
    {
        public Object Object { get; set; }
    }
