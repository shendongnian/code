    private void Foo()
    {
        Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8081);
        udpSocket.Bind(remoteEndPoint);
        SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        byte[] buffer = new byte[1024];
        e.SetBuffer(buffer, 0, buffer.Length);
        e.RemoteEndPoint = remoteEndPoint;
        e.Completed += ReceiveFromCallback;
        if (!udpSocket.ReceiveFromAsync(e))
        {
            ReceiveFromCallback(udpSocket, e);
        }
    }
    private void ReceiveFromCallback(object sender, SocketAsyncEventArgs e)
    {
        if (e.SocketError != SocketError.Success)
        {
            Debug.WriteLine(e.SocketError);
            return;
        }
        Socket udpSocket = sender as Socket;
        byte[] buffer = e.Buffer;
        Debug.WriteLine(Encoding.UTF8.GetString(buffer, 0, e.BytesTransferred));
        if (!udpSocket.ReceiveFromAsync(e))
        {
            ReceiveFromCallback(udpSocket, e);
        }
    }
