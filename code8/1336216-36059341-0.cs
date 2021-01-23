    ...
	TcpClient client = server.AcceptTcpClient();            
	NetworkStream stream = client.GetStream();
	String data = "Message From Server";
	Byte[] bytes = new Byte[256];
	byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
	stream.Write(msg, 0, msg.Length);
    ...
