    public static string[] Split(string input, bool keepDelimiters, params char[] delimiter)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));
        if (input.Length <= 1) return new[] {input};
        List<string> tokens = new List<string>();
        int start = 0, index;
        while ((index = input.IndexOfAny(delimiter, start)) > 0)
        {
            tokens.Add(input.Substring(start, index - start));
            if (keepDelimiters)
                tokens.Add(input[index].ToString());
            start = index + 1;
        }
        if (start < input.Length)
            tokens.Add(input.Substring(start));
        return tokens.ToArray();
    }
