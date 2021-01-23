    public static void GenerateFileNames(int totalFiles, int startIndex)
    {
        for (int i = startIndex; i < totalFiles + startIndex; i++)
        {
            Console.WriteLine(GetString(i));
        }
    }
