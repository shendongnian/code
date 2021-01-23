    public class FooTestable : Foo
    {
        public new bool ProtectedMethod()
        {
            return base.ProtectedMethod();
        }
        public FooTestable () {}
    }
    
    [TestFixture]
    public class FooTests
    {
        [Test]
        public void ProtectedMethod_Test()
        {
            FooTestable fooInstance = new FooTestable();
    
            Assert.That(fooInstance.ProtectedMethod());
        }
    }
