    var test = GetThemOut("[a b c d e f]");
    public static char[] GetThemOut(string array)
    {
        return array.Trim('[', ']')
                    .Where(c => !Char.IsWhiteSpace(c))
                    .ToArray();                          
    }
