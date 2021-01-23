    private static async Task FirstThingAsync()
    {
        var filename = @"c:\temp\tt1.txt";
        if (File.Exists(filename))
            File.Delete(filename);
        using (TextWriter tw = new StreamWriter(filename))
        {
           await tw.WriteLineAsync(DateTime.Now);
        }
    }
