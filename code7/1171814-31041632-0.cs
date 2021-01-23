    private static async Task<string> GetContentStringAsync(HttpContent content, int ResponseContentMaxLength)
    {
        string responseContent;
        Stream responseStream = await content.ReadAsStreamAsync().ConfigureAwait(false);
        int totalBytesRead = 0;
        byte[] buffer = new byte[ResponseContentMaxLength];
        while (totalBytesRead < buffer.Length)
        {
            int bytesRead = await responseStream
                .ReadAsync(buffer, totalBytesRead, buffer.Length - totalBytesRead);
            if (bytesRead == 0)
            {
                // end-of-stream...can't read any more
                break;
            }
            totalBytesRead += bytesRead;
        }
        MemoryStream tempStream = new MemoryStream(buffer, 0, totalBytesRead);
        using (StreamReader streamReader = new StreamReader(tempStream))
        {
            // responseContent = Data from streamReader until ResponseContentMaxLength
        }
    
        return responseContent;
    }
