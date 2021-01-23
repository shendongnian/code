    using Xunit;
    
    public class MyClass
    {
        public MyClass()
        {
            // Some logic to test
        }
    
        public int GetResult()
        {
            return 123;
        }
    }
    
    public class MyClassFacts
    {
        [Fact]
        public void Ctor()
        {
            var myClass = new MyClass();
            Assert.NotNull(myClass);
            // Any other asserts you require
        }
    
        // Nested classes to test each of MyClass' methods
        public class GetResult
        {
            [Fact]
            public void IsCorrect()
            {
                var myClass = new MyClass();
                int result = myClass.GetResult();
                Assert.Equal(123, result);
            }
    
            // Other tests for MyClass.GetResult()...
        }
    }
