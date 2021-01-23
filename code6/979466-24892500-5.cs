    public class MySubObjects
    {
        public List<string> mySubObject { get; set; }
    }
    public class MyObject
    {
        public string someProperty { get; set; }
        public MySubObjects mySubObjects { get; set; }
    }
    public class RootObject
    {
        public MyObject myObject { get; set; }
    }
