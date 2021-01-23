        List<TcpClient> listConnectedClients =  new List<TcpClient>();    	
    	while(true)
    	{
    		TcpClient client = server.AcceptTcpClient(); 
    		listConnectedClients.Add(client);
    	}
