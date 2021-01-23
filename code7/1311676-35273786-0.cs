    public static void ProcessFile(string path)
    {
        FileInfo file = new FileInfo(path);
        Console.WriteLine(file.Name);
    }
