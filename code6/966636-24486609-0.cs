    // Create new socket object
    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
    string query = "mydomain.com";
    NetworkStream nst;
    
    try
    {
    	IPEndPoint endPoint = new IPEndPoint("whois.internic.net", 43)
    	socket.Connect(endPoint);
    	
    	nst = new NetworkStream(socket, true);
    
    	string str;
    	StreamWriter writer = new StreamWriter(nst);
    	writer.WriteLine(query);
    	writer.Flush();
    
    	StringBuilder builder = new StringBuilder();
    	StreamReader reader = new StreamReader(nst);
    	while ((str = reader.ReadLine()) != null)
    	{
    		builder.Append(str);
    		builder.Append(
    #if !NETCF
    			Environment.NewLine
    #else
    			"\r\n"                        
    #endif
    			);
    	}
    	result = builder.ToString();
    }
    finally
    {
    	if (nst != null)
    		nst.Close();
    
    	socket.Close();
    }
