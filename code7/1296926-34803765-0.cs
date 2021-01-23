	this.WriteByteArray(variable)
	reader.ReadBoolean();
	void WriteByteArray(String message)
	{
		byte[] buffer = Encoding.UTF8.GetBytes(message);
		AsyncCallback ac = new AsyncCallback(SendStreamMsg);
		tcpClient.GetStream().BeginWrite(buffer, 0, buffer.Length, ac, null);
	}
