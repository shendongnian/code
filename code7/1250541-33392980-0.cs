	public async Task ConnectAsync()
	{
		TcpClient client = await listener.AcceptTcpClientAsync();
		Logger.Info("Client accepted");
	}
