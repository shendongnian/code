    using (TcpClient client = new TcpClient(socket.HostName, socket.Port))
    {
    	client.SendBufferSize = int.MaxValue;
    	client.ReceiveBufferSize = int.MaxValue;
    
    	Stream stream = client.GetStream();
    	//generally, you should avoid calling Dispose() on an object multiple times
    
    	//don't put this in a using block as that implicitly calls Dispose() which internally calls Dispose on the stream as well
    	StreamReader sr = new StreamReader(stream);
    
    	//don't put this in a using block as that implicitly calls Dispose() which internally calls Dispose on the stream as well
    	StreamWriter sw = new StreamWriter(stream);
    
    	sw.AutoFlush = true;
    	sw.WriteLine("test");
    
    	List<string> xmlStrings = new List<string>();
    	while (sr.Peek() > -1)
    		xmlStrings.Add(sr.ReadLine());
    	string xmlStr = string.Join("\r\n", xmlStrings.ToArray());
    
    	//this calls stream.Dispose as well internally
    	sr.Close();
    	
    	//actually, this also calls stream.Dispose(), but fortunately MS made it safe
    	sw.Close();
    
    	ProcessXMLResponse(xmlStr);
    }
    
    //At this point all IDisposable objects have been disposed of properly (TcpClient, Stream, StreamReader, StreamWriter)
    //we minimized the number of stream.Dispose() calls whereas using 3 using blocks (1 for the stream, 1 for the Reader and 1 for the Writer) would have resulted in 3 calls
