    using System.Web;
    using System.Text.RegularExpressions, 
    
    private string HtmlEntityHex(string strToReplace)
    {
        string strReplaced = HttpUtility.HtmlEncode(strToReplace);
        MatchCollection xMatches = Regex.Matches(strReplaced, @"&#(\d+);");
        foreach (Match xMatch in xMatches)
        {
            strReplaced = strReplaced.Replace(xMatch.Groups[0].Value.ToString(), "&#" + int.Parse(xMatch.Groups[1].Value).ToString("X").PadLeft(4, '0') + ";");
        }
        return strReplaced;
    }
