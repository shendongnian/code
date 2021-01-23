    while (true)
    {
        data = null;
        length = null;
        size = ReceiveExactly(handler,2);
    
        length = Encoding.ASCII.GetString(size, 0, 2); //Why +=?
        bufferSize = Int32.Parse(length); //Why + 2?
        System.Console.WriteLine("Size: " + bufferSize);
    
        bytes = ReceiveExactly(handler,bufferSize);
    
        data += Encoding.ASCII.GetString(bytes, 0, bufferSize);
        System.Console.WriteLine("Data: " + data);
    }
