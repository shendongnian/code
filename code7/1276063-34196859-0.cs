    private byte[] ReadData(TcpClient client, int numBytes)
    {
        var data = new byte[numBytes];
        var totalBytes = 0;
        while (totalBytes < data.Length)
        {
            var bytesRead = client.GetStream().Read(data, totalBytes, data.Length - totalBytes);
            if (bytesRead == 0) break;
            totalBytes += bytesRead;
        }
        if (totalBytes != data.Length)
        {
            // This will occur when the other end of the connection is closed (and so Read() returns zero).
            // You can throw an exception, return null etc. depending on your requirements
            ...
        }
        return data;
    }
