    private static readonly char[] NosCharsToRemove = "0123456789 ".ToCharArray();
    public static string CleanNosFromStr(string text)
    { 
        return text.Trim(NosCharsToRemove);
    }
