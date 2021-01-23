    public static IEnumerable<String> SplitByCount(String input, Int32 count)
    {
        if (input == null) { throw new ArgumentNullException("input"); }
        if (count <= 0) { throw new ArgumentException("Count has to be positive.", "count"); }
        
        for (var i = 0; i < input.Length; i += count)
        {
            yield return input.Substring(i, Math.Min(count, input.Length - i));
        }
    }
