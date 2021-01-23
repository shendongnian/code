    static object _lock = new object(); //somewhere based on your context
    public void SendAsync(byte[] packet)
    {
        Task.Run(() =>
            {
                ..... other codes
                lock (_lock)
                {
                    client.GetStream().BeginWrite(packet, 0, packet.Length, 
                    ar => // the write callback (lambda)
                    {
                        client.GetStream().EndWrite(ar);
                        Console.WriteLine("Sent Data to " + RemoteEndPoint);
                    }, null);
                }
            });
    }
    
   
