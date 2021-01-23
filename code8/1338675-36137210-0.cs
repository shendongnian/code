    var myString = "\"Name\": \"\u0412\u0438\u043d\u043d\u0438\u0446\u0430, \u0443\u043b.\u041a\u0438\u0435\u0432\u0441\u043a\u0430\u044f, 14 - \u0431\",";
    var pattern = "\"Name\":\\s*\"(?<match>[^\"]+)\"";
    Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
    MatchCollection matches = rgx.Matches(myString);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
        {
            var ma = System.Web.HttpUtility.HtmlDecode(match.ToString());
        }
    }
