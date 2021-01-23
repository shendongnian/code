    SSLStream _clientSocket;
    //DataStream class
    public DataStream(SSLStream clientSocket)
    {
        _clientSocket = clientSocket;
    }
    public void Write(string message)
    {
        int toSendLen = Encoding.ASCII.GetByteCount(message);
        byte[] toSendBytes = Encoding.ASCII.GetBytes(message);
        byte[] toSendLenBytes = BitConverter.GetBytes(toSendLen);
        _clientSocket.Write(toSendLenBytes);
        _clientSocket.Write(toSendBytes);
    }
    public String ReadString()
    {
        byte[] rcvLenBytes = new byte[4];
        _clientSocket.Read(rcvLenBytes, 0 , 4);
        int rcvLen = BitConverter.ToInt32(rcvLenBytes, 0);
        byte[] rcvBytes = new byte[rcvLen];
        _clientSocket.Read(rcvBytes, 0, rcvLen);
        var ascii = Encoding.ASCII.GetString(rcvBytes);
        return ascii;
    }
