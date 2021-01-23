    public interface IConcreteClass
    {
        FirstProperty FirstProperty { get; }
    }
        [Test]
        public void TestCase()
        {
            var yourFirstPropertyImplementation = new FirstProperty();
            var concreteClassMock = new Mock<IConcreteClass>();
            concreteClassMock.Setup(o => o.FirstProperty).Returns(yourFirstPropertyImplementation);
        }
