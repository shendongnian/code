    [TestClass]
    public class FooTests
    {
        Mock<Foo> _mockFoo;
        Mock<ISomeDependency> _mockSomeDependency;
        [TestInitialize]
        public void Setup()
        {
            _mockSomeDependency = new Mock<ISomeDependency>();
            _mockFoo = new Mock<Foo>(_mockSomeDependency.Object);
        }
        [TestMethod]
        public void Testing_BazIsNotCalled()
        {
            _mockFoo.CallBase = true;
            _mockFoo.Setup(s => s.Baz());
            _mockFoo.Object.Bar();
            _mockFoo.Verify(v => v.Baz(), Times.Never);
        }
        [TestMethod]
        public void Testing_BazIsCalled()
        {
            _mockFoo.CallBase = true;
            _mockFoo.Setup(s => s.Baz());
            _mockFoo.Object.Bar();
            _mockFoo.Verify(v => v.Baz(), Times.Once);
        }
    }
