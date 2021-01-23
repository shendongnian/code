    private static Dictionary<int, T> Load<T>(string text, Func<string, T> parser)
    {
        return s.Split(';')
                .Where(item => item.Contains("="))
                .Select(item => item.Split('=', 2))
                .ToDictionary(pair => int.Parse(pair[0]), pair => parser(pair[1]));
    }
