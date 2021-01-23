    var tcpListener = new TcpListener(IPAddress.Any, 8088);
    tcpListener.Start();
    tcpListener.BeginAcceptSocket(AsyncAccept, tcpListener);
.......
    void AsyncAccept(IAsyncResult ar)
    {
        var tcpListener = (TcpListener)ar.AsyncState;
        var socket = tcpListener.EndAcceptSocket(ar);
        if (ar.IsCompleted)
        {
            Console.WriteLine(socket.RemoteEndPoint + " connected...");
            var buf = new byte[0x10000];
            socket.BeginReceive(buf, 0, buf.Length, SocketFlags.None, AsyncRead, new Tuple<Socket, byte[]>(socket, buf));
            tcpListener.BeginAcceptSocket(AsyncAccept, tcpListener);
        }
    }
    void AsyncRead(IAsyncResult ar)
    {
        var tuple = (Tuple<Socket, byte[]>)ar.AsyncState;
        var socket = tuple.Item1;
        var buf = tuple.Item2;
        if (ar.IsCompleted)
        {
            var len = socket.EndReceive(ar);
            var str = Encoding.UTF8.GetString(buf, 0, len);
            Console.WriteLine(socket.RemoteEndPoint + ":" + str);
            socket.BeginReceive(buf, 0, buf.Length, SocketFlags.None, AsyncRead, new Tuple<Socket, byte[]>(socket, buf));
        }
    }
