    public class MyParams
    {
        public string linkUri { get; set; }
        // ...
    }
    public class MyAction
    {
        public string type { get; set; }
        public string text { get; set; }
        public MyParams @params { get; set; }
    }
    public class MyOuterObject
    {
        // other properties omitted
        public IDictionary<string, MyAction> myActions { get; set; }
        // ...
    }
