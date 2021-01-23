    public static string SplitCamel(this string stuff)
    {
        var builder = new StringBuilder();
        char? prev = null;
        foreach (char c in stuff)
        {
            if (prev.HasValue && !char.IsWhiteSpace(prev.Value) && 'A' <= c && c <= 'Z') 
                builder.Append(' ');
            builder.Append(c);
            prev = c;
        }
        return builder.ToString();
    }
