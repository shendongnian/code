    private const string fileName = "ServerData.xml";
    public void ProcessBuffer(byte[] receiveBuffer, int bytes)
    {
        File.WriteAllBytes(filename, bytes);
    
    
        // And when reading
        var bytes = File.ReadAllBytes(filename);
        var binaryReader = new BinaryReader(new MemoryStream(bytes));
        // Parse strings and make xml,
        binaryReader.ReadString();
    
    }
