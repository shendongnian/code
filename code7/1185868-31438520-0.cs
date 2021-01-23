	public static void RouterConnect()
	{
		var tcpClient = new TcpClient
		{
			ReceiveTimeout = 2000,
			SendTimeout = 2000
		};
		try
		{
			tcpClient.Connect("192.168.180.1", 23);
			// Rest of your code here
			NetworkStream nStream = tcpClient.GetStream();
		}
		catch (Exception)
		{
			throw;
		}
    }
