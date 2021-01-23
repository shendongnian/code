    byte[] bytes = new byte[(int) fileSize];
    int index = 0;
    while (index < bytes.Length)
    {
        int bytesRead = fileInfo.Stream.Read(byets, index, bytes.Length - index);
        if (bytesRead == 0)
        {
            throw new IOException("Unable to read whole file");
        }
        index += bytesRead;
    }
    
