    public async Task SocketConnect() {
		var tcpClient = new TcpClient();
		for(var retries = 0; retries < 5; retries++)
		{
			try
			{
				await tcpClient.ConnectAsync(host, port);
			}
			catch(Exception ex)
			{
				//handle errors
				continue;
			}
			if(tcpClient.Connected) break;
		}
		if(tcpClient.Connected)
		{
			//yay
		}
    }
