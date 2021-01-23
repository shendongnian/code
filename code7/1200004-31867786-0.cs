    public bool IsMatch(string inputSource, string valueToFind, bool matchWordOnly)
    {
        var regexMatch = matchWordOnly ? string.Format(@"\bany\b", valueToFind) : valueToFind;
        return System.Text.RegularExpressions.Regex.IsMatch(inputSource, regexMatch);
    }
