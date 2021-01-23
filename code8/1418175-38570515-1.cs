    var filePath = "test.txt";
    DateTime creationTime;
    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
    {
        var bytes = Encoding.ASCII.GetBytes("Hello fail.");
        fileStream.Write(bytes, 0, bytes.Length);
        creationTime = DateTime.Now;
    }
    int numTries = 0;
    while (true)
    {
        ++numTries;
        try
        {
            // Attempt to open the file exclusively.
            using (var fileInfo = new FileInfo(filePath))
            {
                fileInfo.CreationTime = creationTime;
                 // If we got this far the file is ready
                break;
            }
        }
        catch (Exception ex)
        {
            if (numTries > 10)
            {
                // Get out of it
            }
            // Wait for the lock to be released
            System.Threading.Thread.Sleep(500);
        }
    }
