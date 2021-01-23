    public static string SplitCamel(this string stuff)
    {
        var builder = new StringBuilder();
        char? prev = null;
        foreach (char c in stuff)
        {
            if (prev.HasValue && !char.IsWhiteSpace(prev.Value) && char.IsUpper(c)) 
                builder.Append(' ');
            builder.Append(c);
            prev = c;
        }
        return builder.ToString();
    }
