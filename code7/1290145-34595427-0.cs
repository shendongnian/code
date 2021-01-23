    try
    {
    	var response = _reader.ReadLine();
    	string command;
    	
    	var result = _sentCommands.TryDequeue(out command);
    
    	if (OnTcpMessage != null && !string.IsNullOrWhiteSpace(response))
    	{
    		// Do something here to take advantage of the command variable
    	}
    }
    //... Rest of code here
