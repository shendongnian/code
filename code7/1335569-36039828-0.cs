    public string createRegex(string word, int count)
    {
        var mandatory = word.Substring(0, count);
        var optional = System.Text.RegularExpressions.Regex.Replace(word.Substring(count), ".", "$0?");
        var regex = @"\b(" + mandatory + ")(?:" + optional + @")\b";
        return regex;
    }
