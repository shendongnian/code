    public class MyClassTests
    {
        private class MyDummyImplementation : IMyInterface { ... }    
        [Fact]
        public void Test()
        {
            var x = new MyDummyImplementation();
        }
    }
