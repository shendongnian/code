    void Receive(UDPClient client)
    {
        var bytes = client.Receive()
        
        mark_kupnr = Swap(BitConverter.ToUInt32(bytes, 0));
        mark_provnr = Swap(BitConverter.ToUInt16(bytes, 4));
        markriktning = Swap(BitConverter.ToUInt16(bytes, 6));
        xpos = Swap(BitConverter.ToUInt16(bytes, 8));
        ypos = Swap(BitConverter.ToUInt16(bytes, 10));
    }
    
    void Send(UDPClient client)
    {
        var listOfBytes = new List<byte>();
        
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(mark_kupnr)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(mark_provnr)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(markriktning)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(xpos)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(ypos)));
      
        client.Send(listOfBytes.ToArray(), listOfBytes.Count);
    }
    
    void Receive(byte[] bytes)
    {      
        mark_kupnr = Swap(BitConverter.ToUInt32(bytes, 0));
        mark_provnr = Swap(BitConverter.ToUInt16(bytes, 4));
        markriktning = Swap(BitConverter.ToUInt16(bytes, 6));
        xpos = Swap(BitConverter.ToUInt16(bytes, 8));
        ypos = Swap(BitConverter.ToUInt16(bytes, 10));
    }
    
    void Send(out byte[] bytes)
    {
        var listOfBytes = new List<byte>();
        
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(mark_kupnr)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(mark_provnr)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(markriktning)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(xpos)));
        listOfBytes.AddRange(BitConverter.GetBytes(Swap(ypos)));
      
        bytes = listOfBytes.ToArray();
    }
