    private static readonly string _SearchPattern = "A12A";
    private static readonly Regex _NumberExtractor = new Regex(@"\d+");
    private static IEnumerable<Tuple<String, int>> FindMatches()
    {
        var startFolder = @"D:\";
        var filePattern = @"*.htm";
        var matchingFiles = Directory.EnumerateFiles(startFolder, filePattern, SearchOption.AllDirectories);
        foreach (var file in matchingFiles)
        {
            // What encoding do your files use?
            var lines = File.ReadLines(file, Encoding.UTF8);
            foreach (var line in lines)
            {
                int number;
                if (TryGetNumber(line, out number))
                {
                    yield return Tuple.Create(file, number);
                    // Stop searching that file and continue with the next one.
                    break;
                }
            }
        }
    }
    private static bool TryGetNumber(string line, out int number)
    {
        number = 0;
        // Should casing be ignored??
        var index = line.IndexOf(_SearchPattern, StringComparison.InvariantCultureIgnoreCase);
        if (index >= 0)
        {
            var numberRaw = line.Substring(index + _SearchPattern.Length);
            var match = _NumberExtractor.Match(numberRaw);
            return Int32.TryParse(match.Value, out number);
        }
        return false;
    }
