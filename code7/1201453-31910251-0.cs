    public async Task ContinouslyReadFromStream(NetworkStream sourceStream, CancellationToken token)
    {
    	while (!ct.IsCancellationRequested && sourceStream.CanRead)
    	{
            while (sourceStream.CanRead && !sourceStream.DataAvailable)
            {
    			// Avoid potential high CPU usage when doing stream.ReadAsync
    			// while waiting for data
                Thread.Sleep(10);
            }
    		
            var lengthOfMessage = BitConverter.ToInt32(await ReadExactBytesAsync(stream, 4, ct), 0);
    		var content = await ReadExactBytesAsync(stream, lengthOfMessage, ct);
    		// Assuming you use UTF8 encoding
    		var stringContent = Encoding.UTF8.GetString(content);
    		
    	}
    }
    
    
    protected static async Task<byte[]> ReadExactBytesAsync(Stream stream, int count, CancellationToken ct)
    {
        var buffer = new byte[count];
        var totalBytesRemaining = count;
        var totalBytesRead = 0;
        while (totalBytesRemaining != 0)
        {
            var bytesRead = await stream.ReadAsync(buffer, totalBytesRead, totalBytesRemaining, ct);
            ct.ThrowIfCancellationRequested();
            totalBytesRead += bytesRead;
            totalBytesRemaining -= bytesRead;
        }
        return buffer;
    }
