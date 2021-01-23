    public async Task<Stream> ReceiveData()
    {
        var buffer = new byte[4096];
        int readBytes = 0;
        SerialPort port = new SerialPort(/* ... */);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            while ((readBytes = await port.BaseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, readBytes);
            }
            return memoryStream;
        }
    }
