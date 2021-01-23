    [Test]
    public async Task AsyncTcpClientNoExceptionTest()
    {
        var asyncAwait = new AsyncTcpClientDemos();
        await asyncAwait.ConnectTcpClientNoException();            
    }
