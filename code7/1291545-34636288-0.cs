    public async Task<bool> IsAliveAsync(IPEndPoint ipEndPoint)
    {
      if (ipEndPoint == null) return false;
      var tcpClient = new TcpClient();
      var connectTask = tcpClient.ConnectAsync(ipEndPoint.Address, ipEndPoint.Port)
      var timeoutTask = Task.Delay(1000);
      var finishedTask = await Task.WhenAny(connectTask, timeoutTask).ConfigureAwait(false);
      bool isAlive;
      if(finishedTask == timeoutTask)
      {
          isAlive = false;
      }
      else
      {
        try
        {
            await connectTask.ConfigureAwait(false);
            isAlive = true;
        }
        catch
        {
          isAlive = false;
        }
      }
                                    
      return isAlive;
    }
