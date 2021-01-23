    [TestMethod]
    public void TestClient()
    {
        Mock<Client> _mockClient = Mock<Client>();
        _mockClient.CallBase = true;
        _mockClient.Setup(foo => foo.funcB(It.IsAny<int>())).Returns("test");
        var testOutput = _mockClient.Object.funcA();
    }
