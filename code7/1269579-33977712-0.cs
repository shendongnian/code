    FileInfo info = new FileInfo(@"D:\SomeMovie.avi");
    int bytesToRead = 128 * 1024 * 1024; // 128MB 
    byte[] buffer = new byte[bytesToRead]; // create the array that will be used encrypted
    long fileOffset = 0;
    int read = 0;
    bool allRead = false;
    while (!allRead)
    {
        using (FileStream fs = new FileStream(info.FullName, FileMode.Open, FileAccess.Read))
        {
            fs.Seek(fileOffset, SeekOrigin.Begin); // continue reading from where we were...
            read = fs.Read(buffer, 0, bytesToRead); // read the next chunk
        }
        if (read == 0)
            allRead = true;
        else
            fileOffset += read;
        // encrypt the stuff, do what you need...
    }
