    static IEnumerable<List<string>> Split(string input)
    {
        return Split(input, new List<string>());
    }
    static IEnumerable<List<string>> Split(string input, List<string> current)
    {
        if (input.Length == 0)
        {
            yield return current;
        }
        if (input.Length >= 1)
        {
            var copy = current.ToList();
            copy.Add(input.Substring(0, 1));
            foreach (var r in Split(input.Substring(1), copy))
                yield return r;
        }
        if (input.Length >= 2)
        {
            var copy = current.ToList();
            copy.Add(input.Substring(0, 2));
            foreach (var r in Split(input.Substring(2), copy))
                yield return r;
        }
    }
