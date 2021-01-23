    public class Step
    {
        public string name { get; set; }
        public List<string> Parameters { get; set; }
    }
    
    public class SubTest
    {
        public string name { get; set; }
        public int index { get; set; }
        public string description { get; set; }
        public List<Step> Steps { get; set; }
    }
    
    public class TestObject
    {
        public string name { get; set; }
        public int index { get; set; }
        public string description { get; set; }
        public List<SubTest> SubTests { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public List<TestObject> testObjects { get; set; }
    }
