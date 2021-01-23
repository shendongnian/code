    public interface IA
    {
        void Get<T>();
    }
    [Fact]
    public void test()
    {
        // Arrange
        bool didCallBackCalled = false;
        var mock = new Mock<IA>();
        mock.Setup(x => x.Get<It.IsAnyType>()).Callback(() => didCallBackCalled = true);
        // Act
        mock.Object.Get<string>();
        // Assert
        Assert.IsTrue(didCallBackCalled);
    }
