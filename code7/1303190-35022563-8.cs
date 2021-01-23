    public static void GenerateFileNames(int totalFiles)
    {
        for (int i = 0; i < totalFiles; i++)
        {
            Console.WriteLine(GetString(i));
        }
    }
    public static string GetString(int index)
    {
        if (index < 26)
        {
            return ((char)('A' + index)).ToString();
        }
    
        return GetString(index / 26 - 1) + GetString(index % 26);
    }
