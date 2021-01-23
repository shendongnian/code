    int count = 0;
    long bytesSoFar = 0;
    foreach (string f in files)
    {
        // ... Your existing work ...
        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
        {
            bytesSoFar += bytesRead;
            // Make sure to only write the number of bytes read from the file
            s.Write(buffer, 0, bytesRead);
            // Console.WriteLine takes a string.Format() style string
            Console.WriteLine("sending file data {0:0.000}%", (bytesSoFar * 100.0f) / totalToUpload);
        }
