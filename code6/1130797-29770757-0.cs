    static readonly Dictionary<char, char> ReplacementChars = new Dictionary<char, char> 
    { 
           { '[', ']'},{']', '['},{')', '('}, {'(', ')'} 
    };
    public static string SwapGroupingSymbols(string str)
    {
        StringBuilder sb = new StringBuilder(str.Length);
        foreach (char c in str)
        {
            char newChar;
            bool contains = ReplacementChars.TryGetValue(c, out newChar);
            sb.Append(contains ? newChar : c);
        }
        return sb.ToString();
    }
