    public static IList<string> ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName)
                   .Where(line => !string.IsNullOrWhiteSpace(line))
                   .ToList();
    }
