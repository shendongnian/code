    public static void WriteToFileAndConsole()
    {
        string outFile = "ConsoleOut.txt";
        using (FileStream fileStream = new FileStream(outFile, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                using (TextWriter originalConsoleOut = Console.Out)
                {
                    Console.SetOut(writer);
                    Console.WriteLine("Hello To File");
                    Console.SetOut(originalConsoleOut);
                }
            }
        }
        Console.WriteLine("Hello to console only");
    }
