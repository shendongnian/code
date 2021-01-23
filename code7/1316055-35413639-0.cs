    public static string RemoveUnwantedSpaces(string text)
    {
        var sb = new StringBuilder();
        char x1 = (char)0;
        char x2 = (char)0;
        foreach (char c in text)
        {
            if (c != ' ' || x1 == ' ' && x2 != ' ')
                sb.Append(c);
            x2 = x1;
            x1 = c;    
        }
        return sb.ToString();
    }
