    static object _lock = new object(); //somewhere based on your context
    public void SendAsync(byte[] packet)
    {
        Task.Run(() =>
            {
                lock (_lock)
                {
                    client.GetStream().BeginWrite(packet, 0, packet.Length, 
                    ar =>
                    {
                        client.GetStream().EndWrite(ar);
                    }, null);
                }
            });
    }
    
   
