    static IEnumerable<List<string>> Split(string input, List<string> row = null)
    {
        if (input.Length == 0)
        {
            yield return row;
        }
        if (input.Length >= 1)
        {
            var copy = (row == null) ? new List<string>() : new List<string>(row);
            copy.Add(input.Substring(0, 1));
            foreach (var r in Split(input.Substring(1), copy))
                yield return r;
        }
        if (input.Length >= 2)
        {
            var copy = (row == null) ? new List<string>() : new List<string>(row);
            copy.Add(input.Substring(0, 2));
            foreach (var r in Split(input.Substring(2), copy))
                yield return r;
        }
    }
