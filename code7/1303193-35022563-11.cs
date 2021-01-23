    public static List<string> GenerateSortedFileNames(int totalFiles)
    {
        List<string> names = new List<string>();
    
        for (int i = 0; i < totalFiles; i++)
        {
            names.Add(GetString(i));
        }
    
        names.Sort();
        
    
        return names;
    }
