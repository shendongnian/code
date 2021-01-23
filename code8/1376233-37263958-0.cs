    using (Stream inStream = args.Socket.InputStream.AsStreamForRead())
    using (StreamReader reader = new StreamReader(inStream))
    {
    	System.Diagnostics.Debug.WriteLine("connection................");
    	//Read line from the remote client.
    	string request = await reader.ReadToEndAsync();
    	System.Diagnostics.Debug.WriteLine(request);  
    }
