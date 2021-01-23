    public static bool ContainsInvalidCharacters(string name)
    {
        return name.IndexOfAny(new[] 
        {
            '\u0001', '\u0002', '\u0003', 
        }) != -1;
    }
