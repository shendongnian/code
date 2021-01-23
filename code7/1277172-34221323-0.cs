	TcpClient c;
	try
	{
		c = _listener.AcceptTcpClient();
	}
	catch (SocketException e)
	{
		Debug.WriteLine("Socket exception was raised: {0}", e);
	}
