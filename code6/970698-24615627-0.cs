    ConcurrentDictionary<Guid, TcpClient> _clients = new ConcurrentDictionary<Guid, TcpClient>();
    
    public async void RunServerAsync()
    {
        tcpListener.Start();
    
        while (true)
        {
            try
            {
                var client = await tcpListener.AcceptTcpClientAsync();
                var clientId = Guid.NewGuid();
                Accept(clientId, client);
                _clients.TryAdd(clientId, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    public Task SendAsync(Guid clientId, Byte[] buffer, Int32 offset, Int32 count)
    {
        TcpClient client;
        if (_clients.TryGetValue(clientId, out client))
            return client.GetStream().WriteAsync(buffer, offset, count);
    
        // client disconnected, throw exception or just ignore
        return Task.FromResult<Object>(null);
    }
    
    public Boolean TryGetClient(Guid clientId, out TcpClient client)
    {
        return _clients.TryGetValue(clientId, out client);
    }
    private async void Accept(Guid clientId, TcpClient client)
    {
        //get client information 
        String clientEndPoint = client.Client.RemoteEndPoint.ToString();
        Console.WriteLine("Client connected at " + clientEndPoint);
    
        await Task.Yield();
    
        try
        {
            using (client)
            using (NetworkStream stream = client.GetStream())
            {
                byte[] dataReceived = new byte[100];
                while (true) //read input stream                    
                {
                    try
                    {
                        int x = await stream.ReadAsync(dataReceived, 0, dataReceived.Length);
    
                        if (x != 0)
                        {
                            //pass on data for processing    
    
                            byte[] dataToSend = await ProcessData(dataReceived);
    
                            //send response,if any, to the client 
                            if (dataToSend != null)
                            {
                                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                                ConsoleMessages.DisplayDataSent(dataReceived, dataToSend);
                            }
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        stream.Close();
                    }
                }
            }
        } //end try           
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
    
        }
        finally
        {
            // deregister client
            _clients.TryRemove(clientId, out client);
        }
    }//end Accept(TcpClient client)
