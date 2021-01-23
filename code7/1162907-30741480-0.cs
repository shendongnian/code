    public interface ITestClassProp
    {
        int Value { get; set; }
    }
    
    public class TestClassProp : ITestClassProp
    {
        public int Value { get; set; }
    }
    
    
    public interface ITestClass<T> where T : ITestClassProp
    {
        ICollection<T> TestProp { get; set; }
    }
    
    public class TestClass : ITestClass<TestClassProp>
    {
        public ICollection<TestClassProp> TestProp { get; set; }
    }
