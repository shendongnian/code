    public class TestClass
    {
        public delegate void SampleDelegate();
        public SampleDelegate SampleEvent;
    }
    public void TestMethod()
    {
        var a = new TestClass();
        a.SampleEvent();
    }
