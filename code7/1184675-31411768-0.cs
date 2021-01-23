    void Parse()
    {
        foreach (var line in GetFileLines())
        {
        }
    }
    IEnumerable<string> GetFileLines()
    {
        foreach (var fileName in Directory.EnumerateFiles(Path))
        {
            foreach (var line in File.ReadLines(fileName)
            {
                yield return line;
            }
        }
    }
