    void Main()
    {
        const string filePath = @"d:\temp\test.txt";
        var encoding = Encoding.UTF8;
        using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        using (var reader = new StreamReader(stream, encoding))
        using (var writer = new StreamWriter(stream, encoding))
        {
            // Read
            var contents = reader.ReadToEnd();
    
            // Transform
            var transformedContents = contents.Substring(0, Math.Max(0, contents.Length - 1));
    
            // Write out transformed contents from the start of the file
            stream.Position = 0;
            writer.Write(transformedContents);
            writer.Flush();
    
            // Truncate
            stream.SetLength(stream.Position);
        }
    }
