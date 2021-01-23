    [Test]
    public void AsyncTcpClientNoExceptionTest()
    {
        var asyncAwait = new AsyncTcpClientDemos();
        asyncAwait.ConnectTcpClientNoException().GetAwaiter().GetResult();
    }
