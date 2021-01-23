    public static IList<string> ReadFile(string fileName)
    {
        var results = new List<string>();
        var target = File.ReadAllLines(fileName)
                         .Where(line => !string.IsNullOrWhiteSpace(line))
                         .ToList();
        return results;
    }
