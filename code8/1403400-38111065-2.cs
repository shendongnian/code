    [TestMethod]
    public void TestTcpClient()
    {
        var mockedTcpClient = new Mock<ITCPClient>();
        mockedTcpClient.Setup(x => x.SendMessage(It.IsAny<string>())).Verifiable();
        //mockedTcpClient.Object.SendMessage("test");
        mockedTcpClient.Verify(x=>x.SendMessage("test"));
    }
