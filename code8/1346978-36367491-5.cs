    FileStream fs = new FileStream("path.txt", FileMode.Open, FileAccess.Read, FileShare.None, 1024 * 1024);
    
    long lineCount = 0;
    byte[] buffer = new byte[1024 * 1024];
    int bytesRead;
    
    do
    {
        bytesRead = fs.Read(buffer, 0, buffer.Length);
        for (int i = 0; i < bytesRead; i++)
            if (bytesRead == '\n')
                lineCount++;
    }
    while (bytesRead > 0);
