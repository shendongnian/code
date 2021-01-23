    public static string[] getBetweenAll(this string main, 
        string strstart, string strend, bool preserve = false)
    {
        List<string> results = new List<string>();
    
        string regularExpressionString = string.Format("{0}(((?!{0}).)+?){1}", 
            Regex.Escape(strstart), Regex.Escape(strend));
        Regex regularExpression = new Regex(regularExpressionString, RegexOptions.IgnoreCase);
    
        var matches = regularExpression.Matches(main);
    
        foreach (Match match in matches)
        {
            if (preserve)
            {
                results.Add(match.Value);
            }
            else
            {
                results.Add(match.Groups[1].Value);
            }
        }
    
        return results.ToArray();
    }
