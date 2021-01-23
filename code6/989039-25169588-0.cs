    using System.Collections.Generic;
    using System.Text.RegularExpressions;
        static string[] ParseLinkToJpg(string str)
        {
            Regex regex = new Regex(@"(http:.*?\.jpg)");
            Match match = regex.Match(str);
            List<string> result=new List<string>();
            while (match.Success)
            {
                result.Add(match.Groups[1].ToString());
                match = match.NextMatch();
            }
            return result.ToArray();
        }
