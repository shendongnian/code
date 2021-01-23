    public static void LogThis(object toWrite)
    {
        string path = @"C:\temp\ExampleNew.txt";
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        TextWriter tw = new StreamWriter(path, true);
        tw.WriteLine(toWrite);
        tw.WriteLine();
        tw.Close(); 
    }
