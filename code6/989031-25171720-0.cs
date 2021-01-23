    string input =  System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase("hello there, this is the 1st");
    string result = System.Text.RegularExpressions.Regex.Replace(input, "([0-9]st)|([0-9]th)|([0-9]rd)|([0-9]nd)", new System.Text.RegularExpressions.MatchEvaluator((m) =>
    {
        return m.Captures[0].Value.ToLower();
    }), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
