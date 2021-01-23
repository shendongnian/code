    private async void AcceptClient(TcpClient client)
    {
      await Task.Factory.StartNew(() => ProcessClientAsync(client), TaskCreationOptions.LongRunning);
    }
    
    private async void Run()
    {
      while (!_isStopRequested)
      {
           TcpClient client = await _tcpListener.AcceptTcpClientAsync();
           AcceptClient(client);
      }
    } 
