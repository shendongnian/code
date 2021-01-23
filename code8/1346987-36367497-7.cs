    void Main()
    {
        var filePath = @"c:\MyHugeFile.txt";
        // Make sure you clear windows cache!
        UsingFileStream(filePath);
    
        // Make sure you clear windows cache!
        UsingStreamReaderLinq(filePath);
        
        // Make sure you clear windows cache!
        UsingStreamReader(filePath);
    }
    
    private void UsingFileStream(string path)
    {
        var sw = Stopwatch.StartNew();
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            long lineCount = 0;
            byte[] buffer = new byte[1024 * 1024];
            int bytesRead;
            
            do
            {
                bytesRead = fs.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < bytesRead; i++)
                    if (buffer[i] == '\n')
                        lineCount++;
            }
            while (bytesRead > 0);       
            Console.WriteLine("[FileStream] - Read: {0:n0} in {1}", lineCount, sw.Elapsed);
        }
    }
    
    private void UsingStreamReaderLinq(string path)
    {
        var sw = Stopwatch.StartNew();
        var lineCount = File.ReadLines(path).Count();
        Console.WriteLine("[StreamReader+LINQ] - Read: {0:n0} in {1}", lineCount, sw.Elapsed);
    }
    
    private void UsingStreamReader(string path)
    {
        var sw = Stopwatch.StartNew();
        long lineCount = 0;
        string line;
        using (var file = new StreamReader(path))
        {
            while ((line = file.ReadLine()) != null) { lineCount++; }
            Console.WriteLine("[StreamReader] - Read: {0:n0} in {1}", lineCount, sw.Elapsed);
        }
    }
