    static void Main(string[] args)
    {
        string path = @"C:\TEMP\testFile.txt";
        FileInfo filepath = new FileInfo(path);
        Console.WriteLine("Opening \"filepath\"");
        filepath.Open();
        FileInfo filepath2 = new FileInfo(path);
        if (IsFileLocked(filepath2)) {
            Console.WriteLine("File is currently locked");
        }
        else
        {
            Console.WriteLine("File is currently NOT locked");
        }
        Console.WriteLine("Closing \"filepath\"");
        filepath.Close();
        if (IsFileLocked(filepath2)) {
            Console.WriteLine("File is currently locked");
        }
        else
        {
            Console.WriteLine("File is currently NOT locked");
        }
    }
