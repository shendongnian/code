    void Main()
    {
        CalledMethod(CreateDefault("Hello World"));
    }
    
    void CalledMethod<TSource>(TSource defaultValue)
    {
    }
    
    TestClass CreateDefault(string message)
    {
        return new TestClass() { Message = message, };
    }
    
    public class TestClass
    {
        public string Message { get; set; } = null;
        public TestClass() { }
    }
