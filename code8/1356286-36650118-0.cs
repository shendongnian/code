    stream.Position = 0;
    using(FileStream fs = new FileStream("newPNG.png"))
    {
        int totalBytesRead = 0;
        while(totalBytesRead < stream.Length)
        {
            byte[] byteBuffer = new byte[8192];
            int bytesRead = stream.Read(readBytes, 0, byteBuffer.Length);
            fs.Write(byteBuffer, totalBytesRead, bytesRead);
            totalBytesRead += bytesRead;
        }
    }
    stream.Position = 0;
