    public static IEnumerable<string> GetCharCountPlaceholders(IEnumerable<char> chars, char placeholder = '*', string charCountDelimiter = " - ")
    {
        return chars
            .GroupBy(c => c)
            .OrderBy(g => g.Key)
            .Select(g => String.Format("{0}{1}{2}"
             , g.Key
             , charCountDelimiter
             , new String(placeholder, g.Count())));
    }
