    public class A
    {
        public string test { get; set; }
        public YourGroup folder;
        class YourGroup
        {
            public string test2 {get; set; }
        }
    }
    A a = new A();
    a.test = "";
    a.folder.test2 = "";
