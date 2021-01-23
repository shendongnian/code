    public static string trimString(string str, int maxCharacters = 16)
    {
        if (str.Length <= maxCharacters)
        {
            return str;
        }
        int MaxLen =  Math.Min(maxCharacters/2, str.Length);
        return str.Substring(0, MaxLen) +"..."+ str.Substring(str.Length - MaxLen, MaxLen);
    }
