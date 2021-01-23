    static string CapitalSplit(string str)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in str)
        {
            if (char.IsUpper(c))
                result.Append(' ').Append(c);
            else
                result.Append(c);
        }
        return result.ToString().TrimStart(' ');
    }
