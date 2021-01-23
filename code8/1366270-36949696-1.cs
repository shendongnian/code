    Interface IA
    {
        void foo();
        T Get<T>();
    }
    [Fact]
    public void SetupGenericMethod()
    {
        var mockT = new Mock<FakeType>(); 
        var mock = new Mock<IA>();
        mock.Setup(x=> x.Get<FakeType>()).Returns(mockT.Object);
    }
