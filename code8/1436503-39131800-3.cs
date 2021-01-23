    public class Child
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DurationMilliseconds { get; set; }
        public double StartMilliseconds { get; set; }
        public List<Child> Children { get; set; }
        public object CustomTimings { get; set; }
    }
    
    public class Root
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double DurationMilliseconds { get; set; }
        public int StartMilliseconds { get; set; }
        public List<Child> Children { get; set; }
        public object CustomTimings { get; set; }
    }
    
    public class RootObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Started { get; set; }
        public double DurationMilliseconds { get; set; }
        public string MachineName { get; set; }
        public object CustomLinks { get; set; }
        public Root Root { get; set; }
        public object ClientTimings { get; set; }
        public string User { get; set; }
        public object Storage { get; set; }
    }
