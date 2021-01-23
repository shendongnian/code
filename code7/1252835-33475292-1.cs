    HashSet<char> AllowedChars = new HashSet<char>("0123456789numkMGHzVs%-.");
    private string RemoveUnwantedChar(string input)
    {
        StringBuilder sb = new StringBuilder(input.Length);
        foreach (char c in input)
            if (AllowedChars.Contains(c))
                sb.Append(c);
        return sb.ToString();
    }
