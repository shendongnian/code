    [TestMethod]
    public void TestSend()
    {
       var mockClient = new Mock<IClient>();
       mockClient.Setup(x => x.SendMsg(It.IsAny<byte[]>())).Callback<byte[]>((m) => Send(m));
       // ....
       Assert.IsTrue(isInit);
    }
