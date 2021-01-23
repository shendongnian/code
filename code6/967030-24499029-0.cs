    socket.BeginReceive(buffer, 0, size, SocketFlags.None, receive, buffer/*state*/);
    
    public void receive(IAsyncResult ar) {
        // How to get buffer:
        var buffer = (byte[])ar.AsyncState;
        var bytesRead = socket.EndReceive(ar);
        
    }
