    public static IList<string> ReadFile(string fileName)
    {
        File.ReadAllLines(fileName)
            .SelectMany(line => line.Split(','))
            .Where(item => !string.IsNullOrWhiteSpace(item))
            .ToList();
    }
