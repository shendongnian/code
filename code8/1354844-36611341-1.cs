    //make connection
    NetworkStream stream = null;
    socket = new TcpClient();
    socket.Connect("192.168.12.12", 15879);
    if (socket.Connected) {
        stream = socket.GetStream();
    }
    
    //and than wait for tcp packets.
    connectionThread = new Thread(ListenServer);
    connectionThread.Start();
    private void ListenToServer() {
        Byte[] data = new Byte[1024];
        String message = String.Empty;
        Int32 dataLength = 0;
        while (socket.Connected) {
        try {
            while (stream.DataAvailable) {
                dataLength = stream.Read(data, 0, data.Length);
                message = System.Text.Encoding.UTF8.GetString(data, 0, dataLength);
                //do what ever you need here
                Thread.Sleep(1);
            }
        } catch (Exception ex) {
        }
        Thread.Sleep(100);
    }
