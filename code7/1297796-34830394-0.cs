    static IEnumerable<String> SplitLines(string path, string splitPattern)
    {
        foreach (string line in File.ReadAllLines(path))
            foreach (string part in Regex.Split(line, splitPattern))
                yield return part;
    }
