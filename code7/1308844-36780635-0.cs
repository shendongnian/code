    while (!_shutdownEvent.WaitOne(0))
    {
        IAsyncResult result = listener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
        connectionWaitHandle.WaitOne();
    }
