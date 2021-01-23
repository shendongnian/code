    /// <summary>
    /// Helper method to read the specified byte array (number of bytes to read is the size of the array).
    /// </summary>
    /// <param name="inputStream">Input stream.</param>
    /// <param name="buffer">The output buffer.</param>
    private static void ReadFully(Stream inputStream, byte[] buffer)
    {
        if (inputStream == null)
        {
            throw new ArgumentNullException("inputStream");
        }
        if (buffer == null)
        {
            throw new ArgumentNullException("buffer");
        }
        int totalBytesRead = 0;
        int bytesLeft = buffer.Length;
        if (bytesLeft <= 0)
        {
            throw new ArgumentException("There is nothing to read for the specified buffer", "buffer");
        }
        while (totalBytesRead < buffer.Length)
        {
            var bytesRead = inputStream.Read(buffer, totalBytesRead, bytesLeft);
            if (bytesRead > 0)
            {
                totalBytesRead += bytesRead;
                bytesLeft -= bytesRead;
            }
            else
            {
                throw new InvalidOperationException("Input stream reaches the end before reading all the bytes");
            }
        }
    }
    
    public void start()
    {
        ...
        int size = ns.ReadByte();
        byte[] buff = new byte[size];
        ReadFully(ns, buff);
        using (var memoryStream = new MemoryStream(buff, false))
        {
            // The StreamReader class is used to extract the UTF-8 string which is encoded with the byte order mark (BOM).
            using (var streamReader = new StreamReader(memoryStream, Encoding.UTF8))
            {
                string message = streamReader.ReadToEnd();
                Console.WriteLine("Message from Client: {0}", message);
            }
        }
        ...
    }
