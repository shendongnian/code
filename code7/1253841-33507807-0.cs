    public static string GetEntryFromConfigFile(string fileName, string entryToFind)
    {
        var m = File.ReadLines(fileName).Where(l => l.StartsWith(entryToFind, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();	
        return m;
    }
