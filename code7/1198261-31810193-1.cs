    public byte[] ReadFile(NetworkStream ns)
    {
        var header = new byte[4];
        var bytesLeft = 4;
        var offset = 0;
        
        // have to repeat as messages can come in chunks
        while (bytesLeft > 0)
        {
            var bytesRead = ns.Read(header, offset, bytesLeft);
            offset += bytesRead;
            bytesLeft -= bytesRead;
        }
        
        bytesLeft = BitConverter.ToInt32(header, 0);
        offset = 0;
        var fileContents = new byte[bytesLeft];
        
        // have to repeat as messages can come in chunks
        while (bytesLeft > 0)
        {
            var bytesRead = ns.Read(fileContents, offset, bytesLeft);
            offset += bytesRead;
            bytesLeft -= bytesRead;
        }
        
        return fileContents;
    }
