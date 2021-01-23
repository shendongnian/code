    public static string RemoveNewLines(this string input)
    {
        return input.Replace("\r\n", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);
    }
