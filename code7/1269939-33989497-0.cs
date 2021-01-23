    public void ReceiveMessage()
    {
        try {
           await socket.ReceiveAsync(messageBuffer,0,messageBuffer.Length,SocketFlags.None);
           aMessage = Encoding.ASCII.GetString(messageBuffer, 0, rec);
        } catch (Exception ex) {
           Console.WriteLine("SEND ERROR\n{0}", ex.Message);
        }
    }
