    public static string LargestCommonPrefix(string first, string second)
    {
        return new string(first.Zip(second, Tuple.Create)
            .TakeWhile(pair => pair.Item1 == pair.Item2)
            .Select(pair => pair.Item1)
            .ToArray());
    }
