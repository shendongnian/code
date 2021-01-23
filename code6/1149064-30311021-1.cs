	using (TcpClient client = new TcpClient(ip, port))
	{
		var stm = client.GetStream();
		stm.Write(data, 0, data.Length); //Write some data to the stream
		
		byte[] resp = new byte[1024];
		var memStream = new MemoryStream();
		var bytes = 0;
		client.Client.ReceiveTimeout = 200;
		
		do
		{
			try
			{
				bytes = stm.Read(resp, 0, resp.Length);
				memStream.Write(resp, 0, bytes);
			}
			catch (IOException ex)
			{
				// if the ReceiveTimeout is reached an IOException will be raised...
				// with an InnerException of type SocketException and ErrorCode 10060
				var socketExept = ex.InnerException as SocketException;
				if (socketExept == null || socketExept.ErrorCode != 10060)
				// if it's not the "expected" exception, let's not hide the error
				throw ex;
				// if it is the receive timeout, then reading ended
				bytes = 0;
			}
		} while (bytes > 0);
		
		return memStream.ToArray();
	}
