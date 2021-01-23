    IObservable<TcpClient> clients = listener
        .StartSocketObservable(1)
        .SelectMany<Socket, TcpClient>(socket => SocketToTcpClient(socket))
        .Finally(listener.Stop)
        .Publish().RefCount();
