    public class TestViewModel
    {
        public Object1 Test1 { get; set; }
        public Object2 Test2 { get; set; }
        public TestViewModel()
        {
        }
        public TestViewModel(Object1 one, Object2 two)
        {
            Test1 = one;
            Test2 = two;
        }
    }
    public class Object1
    {
        public string TestString1 { get; set; }
    }
    public class Object2
    {
        public string TestString2 { get; set; }
    }
